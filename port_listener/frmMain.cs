﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

using System.Management;
using System.Text.RegularExpressions;

namespace port_listener {
    public partial class frmMain: Form {
        private string log_data = string.Empty;
        private SerialPort serialport;

        public frmMain() {
            InitializeComponent();

            this.MinimumSize = this.Size;

            getAvailablePorts();

            cbBaudRate.SelectedIndex = 0;
            cbDataBit.SelectedIndex = 2;
            cbParity.SelectedIndex = 2;
            cbStopBit.SelectedIndex = 1;

            if( cbPortName.Items.Count == 0 ) {
                btnListen.Enabled = false;
                cbBaudRate.Enabled = false;
                cbDataBit.Enabled = false;
                cbParity.Enabled = false;
                cbStopBit.Enabled = false;
            } else {
                cbPortName.SelectedIndex = 0;
            }

            btnStop.Enabled = false;

            rtbData.Enabled = true;
            rtbData.ReadOnly = true;
            rtbData.BackColor = Color.White;
        }

        private void cbPortName_SelectedIndexChanged( object sender, EventArgs e ) {
            if( ((ComboBox)sender).SelectedIndex == -1 ) {
                btnListen.Enabled = false;
                cbBaudRate.Enabled = false;
                cbDataBit.Enabled = false;
                cbParity.Enabled = false;
                cbStopBit.Enabled = false;
            } else {
                btnListen.Enabled = true;
                cbBaudRate.Enabled = true;
                cbDataBit.Enabled = true;
                cbParity.Enabled = true;
                cbStopBit.Enabled = true;
            }
        }

        private void btnListen_Click( object sender, EventArgs e ) {
            log_data = string.Empty;

            if ( cbPortName.SelectedIndex == -1 ) {
                return;
            }

            serialport = new SerialPort();

            serialport.PortName = ( (serial_port)cbPortName.SelectedItem ).port_id;
            serialport.BaudRate = Convert.ToInt32( cbBaudRate.SelectedItem );
            serialport.DataBits = Convert.ToInt32( cbDataBit.SelectedItem );
            serialport.Handshake = Handshake.None;
            serialport.RtsEnable = false;
            serialport.DtrEnable = false;

            switch ( cbParity.SelectedIndex ) {
                case 0: serialport.Parity = Parity.None; break;
                case 1: serialport.Parity = Parity.Odd; break;
                case 2: serialport.Parity = Parity.Even; break;
                case 3: serialport.Parity = Parity.Mark; break;
                case 4: serialport.Parity = Parity.Space; break;
            }

            switch ( cbStopBit.SelectedIndex ) {
                case 0: serialport.StopBits = StopBits.None; break;
                case 1: serialport.StopBits = StopBits.One; break;
                case 2: serialport.StopBits = StopBits.Two; break;
                case 3: serialport.StopBits = StopBits.OnePointFive; break;
            }

            serialport.ReadTimeout = 500;
            serialport.WriteTimeout = 500;

            serialport.DataReceived += new SerialDataReceivedEventHandler( DataReceivedHandler );

            serialport.Open();

            btnListen.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click( object sender, EventArgs e ) {
            serialport.Close();

            btnListen.Enabled = true;
            btnStop.Enabled = false;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e ) {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();

            ParseReadData( data );
        }

        private void ParseReadData( string data ) {
            if( rtbData.InvokeRequired ) {
                rtbData.BeginInvoke( (MethodInvoker)delegate () { ParseReadData( data ); } );
            } else {
                log_data += data;
                rtbData.Text += replaceSpecialChars( data );

                if( cbAuto.Checked ) {
                    MatchCollection mcReadoutLines = Regex.Matches(log_data, "\x06([0-9]{3})\r\n");
                    if ( mcReadoutLines.Count > 0 ) {
                        int baudrate = 0;
                        switch ( mcReadoutLines[ 0 ].Groups[ 1 ].Value.Substring( 1, 1 ) ) {
                            case "0": baudrate = 300; break;
                            case "1": baudrate = 600; break;
                            case "2": baudrate = 1200; break;
                            case "3": baudrate = 2400; break;
                            case "4": baudrate = 4800; break;
                            case "5": baudrate = 9600; break;
                            case "6": baudrate = 19200; break;
                            default: throw new System.ArgumentException( "unknownBaudrate" );
                        }

                        if ( serialport.BaudRate != baudrate ) {
                            serialport.Close();
                            serialport.BaudRate = baudrate;
                            serialport.Open();
                        }
                    }
                }
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            rtbData.Clear();
        }

        void RTBGotFocus( object sender, System.EventArgs e ) {
            SendKeys.Send( "{tab}" );
        }

        public string replaceSpecialChars( string text ) {
            string strReturn = string.Empty;
            char[] chrReturn;

            chrReturn = text.ToCharArray();

            for ( int i = 0; i < chrReturn.Length; i++ ) {
                if ( chrReturn[ i ] < 18 ) {
                    strReturn += "<" + String.Format( "0x{0:X2}", Convert.ToInt32( chrReturn[ i ] ) ) + ">";
                } else {
                    strReturn += chrReturn[ i ].ToString();
                }
            }

            return strReturn.Replace( "<0x0A>", "<0x0A>\r\n" );
        }

        void getAvailablePorts() {
            try {
                using ( ManagementObjectSearcher searcher = new ManagementObjectSearcher( "root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'" ) ) {
                    foreach ( ManagementObject s in searcher.Get() ) {
                        cbPortName.Items.Add( new serial_port( s[ "Name" ].ToString() ) );
                    }
                }
            } catch {

            }
        }
    }

    public class serial_port {
        public string port_name;
        public string port_id;

        public serial_port(string port_name) {
            this.port_name = port_name;
            this.port_id = port_name.Substring( port_name.IndexOf("(COM") + 1, port_name.IndexOf(")") - port_name.IndexOf( "(COM" ) - 1 );
        }

        public override string ToString() {
            return this.port_name;
        }
    }
}
