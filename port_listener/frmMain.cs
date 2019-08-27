using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Be.Windows.Forms;

using System.Management;
using System.Text.RegularExpressions;
using System.Globalization;

namespace port_listener {
    public partial class frmMain: Form {
        private string log_data = string.Empty;
        private SerialPort serialport;
        private readonly DynamicByteProvider dynamicByteProvider = new DynamicByteProvider( new byte[] { } );
        private readonly csettings settings = new csettings();

        public frmMain() {
            InitializeComponent();

            this.MinimumSize = this.Size;

            getAvailablePorts();

            settings.Get();
            cbAuto.Checked = settings.auto_baud_switch;
            for(int i = 0; i < cbPortName.Items.Count; i++ ) {
                if( cbPortName.Items[i].ToString() == settings.serial_port_name ) {
                    cbPortName.SelectedIndex = i;
                }
            }
            cbBaudRate.SelectedIndex = cbBaudRate.Items.IndexOf( settings.baud_rate );
            cbDataBit.SelectedIndex = cbDataBit.Items.IndexOf( settings.data_bit );
            cbParity.SelectedIndex = cbParity.Items.IndexOf( settings.parity );
            cbStopBit.SelectedIndex = cbStopBit.Items.IndexOf( settings.stop_bit );
            
            if( settings.dtr ) {
                rbDTROn.Checked = true;
            } else {
                rbDTROff.Checked = true;
            }

            if( settings.rts ) {
                rbRTSOn.Checked = true;
            } else {
                rbRTSOff.Checked = true;
            }

            if( cbPortName.Items.Count == 0 ) {
                btnListen.Enabled = false;
                cbBaudRate.Enabled = false;
                cbDataBit.Enabled = false;
                cbParity.Enabled = false;
                cbStopBit.Enabled = false;
                rbDTROff.Enabled = false;
                rbDTROn.Enabled = false;
                rbRTSOff.Enabled = false;
                rbRTSOn.Enabled = false;
            } else if( cbPortName.SelectedIndex == -1 ) {
                cbPortName.SelectedIndex = 0;
            }

            btnStop.Enabled = false;

            hbSerialData.Enabled = true;
            hbSerialData.ReadOnly = true;
            hbSerialData.BackColor = Color.White;
            hbSerialData.ByteProvider = dynamicByteProvider;

            nudBytePerLine.Value = settings.bytes_per_line;
            nudGroupSize.Value = settings.group_size;

            dynamicByteProvider.Changed += new EventHandler( byteProvider_Changed );
            dynamicByteProvider.LengthChanged += new EventHandler( byteProvider_LengthChanged );

            nudGroupSize.Maximum = nudBytePerLine.Value;
        }

        private void FrmMain_FormClosing( object sender, FormClosingEventArgs e ) {
            settings.auto_baud_switch = cbAuto.Checked;
            settings.dtr = rbDTROn.Checked;
            settings.rts = rbRTSOn.Checked;

            settings.bytes_per_line = Convert.ToInt32( nudBytePerLine.Value );
            settings.group_size = Convert.ToInt32( nudGroupSize.Value );

            settings.serial_port_name = cbPortName.SelectedItem.ToString();
            settings.baud_rate = cbBaudRate.SelectedItem.ToString();
            settings.data_bit = cbDataBit.SelectedItem.ToString();
            settings.parity = cbParity.SelectedItem.ToString();
            settings.stop_bit = cbStopBit.SelectedItem.ToString();

            settings.Save();
        }

        void byteProvider_Changed( object sender, EventArgs e ) {
            hbSerialData.Refresh();
        }

        void byteProvider_LengthChanged(object sender, EventArgs e) {
            if(hbSerialData.ByteProvider == null)
                fileSizeToolStripStatusLabel.Text = string.Empty;
            else
                fileSizeToolStripStatusLabel.Text = GetDisplayBytes( (double)hbSerialData.ByteProvider.Length );
        }

        public static string GetDisplayBytes( double size ) {
            const long multi = 1024;
            const long kb = multi;
            const long mb = kb * multi;
            const long gb = mb * multi;
            const long tb = gb * multi;

            const string BYTES = "Bytes";
            const string KB = "KB";
            const string MB = "MB";
            const string GB = "GB";
            const string TB = "TB";

            if(size < kb)
                return string.Format( "{0} {1}", size, BYTES );
            else if(size < mb)
                return string.Format( "{0:0.00} {1}", size / kb, KB );
            else if(size < gb)
                return string.Format( "{0:0.00} {1}", size / mb, MB );
            else if(size < tb)
                return string.Format( "{0:0.00} {1}", size / gb, GB );
            else
                return string.Format( "{0:0.00} {1}", size / tb, TB );
        }

        private void cbPortName_SelectedIndexChanged( object sender, EventArgs e ) {
            if( ((ComboBox)sender).SelectedIndex == -1 ) {
                btnListen.Enabled = false;
                cbBaudRate.Enabled = false;
                cbDataBit.Enabled = false;
                cbParity.Enabled = false;
                cbStopBit.Enabled = false;
                rbDTROff.Enabled = false;
                rbDTROn.Enabled = false;
                rbRTSOff.Enabled = false;
                rbRTSOn.Enabled = false;
            } else {
                btnListen.Enabled = true;
                cbBaudRate.Enabled = true;
                cbDataBit.Enabled = true;
                cbParity.Enabled = true;
                cbStopBit.Enabled = true;
                rbDTROff.Enabled = true;
                rbDTROn.Enabled = true;
                rbRTSOff.Enabled = true;
                rbRTSOn.Enabled = true;
            }
        }

        private void btnListen_Click( object sender, EventArgs e ) {
            log_data = string.Empty;

            if ( cbPortName.SelectedIndex == -1 ) {
                return;
            }

            serialport = new SerialPort {
                PortName = ( (serial_port)cbPortName.SelectedItem ).port_id,
                BaudRate = Convert.ToInt32( cbBaudRate.SelectedItem ),
                DataBits = Convert.ToInt32( cbDataBit.SelectedItem ),
                Handshake = Handshake.None,
                RtsEnable = false,
                DtrEnable = false
            };

            connectionSettingRateToolStripStatusLabel.Text = serialport.DataBits.ToString();

            switch( (string)cbParity.SelectedItem ) {
                case "None":
                    serialport.Parity = Parity.None;
                    connectionSettingRateToolStripStatusLabel.Text += "N";
                break;

                case "Odd":
                    serialport.Parity = Parity.Odd;
                    connectionSettingRateToolStripStatusLabel.Text += "O";
                break;

                case "Even":
                    serialport.Parity = Parity.Even;
                    connectionSettingRateToolStripStatusLabel.Text += "E";
                break;

                case "Mark":
                    serialport.Parity = Parity.Mark;
                    connectionSettingRateToolStripStatusLabel.Text += "M";
                break;

                case "Space":
                    serialport.Parity = Parity.Space;
                    connectionSettingRateToolStripStatusLabel.Text += "S";
                break;
            }

            switch( cbStopBit.SelectedIndex ) {
                case 0:
                    serialport.StopBits = StopBits.None;
                break;

                case 1:
                    serialport.StopBits = StopBits.One;
                    connectionSettingRateToolStripStatusLabel.Text += "1";
                break;

                case 2:
                    serialport.StopBits = StopBits.Two;
                    connectionSettingRateToolStripStatusLabel.Text += "2";
                break;

                case 3:
                    serialport.StopBits = StopBits.OnePointFive;
                    connectionSettingRateToolStripStatusLabel.Text += "15";
                break;
            }

            serialport.DtrEnable = ( rbDTROn.Checked ) ? ( true ) : ( false );
            serialport.RtsEnable = ( rbRTSOn.Checked ) ? ( true ) : ( false );

            serialport.ReadTimeout = 500;
            serialport.WriteTimeout = 500;

            serialport.DataReceived += new SerialDataReceivedEventHandler( DataReceivedHandler );
            serialport.Encoding = Encoding.GetEncoding( "Windows-1252" );

            serialport.Open();

            cbAuto.Enabled = false;
            cbPortName.Enabled = false;
            cbBaudRate.Enabled = false;
            cbDataBit.Enabled = false;
            cbParity.Enabled = false;
            cbStopBit.Enabled = false;
            btnListen.Enabled = false;
            btnStop.Enabled = true;
            rbDTROff.Enabled = false;
            rbDTROn.Enabled = false;
            rbRTSOff.Enabled = false;
            rbRTSOn.Enabled = false;

            baudRateToolStripStatusLabel.Text = serialport.BaudRate + "bps";
        }

        private void btnStop_Click( object sender, EventArgs e ) {
            serialport.Close();

            cbAuto.Enabled = true;
            cbPortName.Enabled = true;
            cbBaudRate.Enabled = true;
            cbDataBit.Enabled = true;
            cbParity.Enabled = true;
            cbStopBit.Enabled = true;
            btnListen.Enabled = true;
            btnStop.Enabled = false;
            rbDTROff.Enabled = true;
            rbDTROn.Enabled = true;
            rbRTSOff.Enabled = true;
            rbRTSOn.Enabled = true;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e ) {
            SerialPort sp = (SerialPort)sender;

            byte[ ] data = new byte[ sp.BytesToRead ];
            if( sp.BytesToRead > 0 ) {
                sp.Read( data, 0, data.Length );
            }

            ParseReadData( data );
        }

        private void ParseReadData( byte[] data ) {
            if(hbSerialData.InvokeRequired ) {
                hbSerialData.BeginInvoke( (MethodInvoker)delegate () { ParseReadData( data ); } );
            } else {
                log_data += data;
                dynamicByteProvider.InsertBytes( dynamicByteProvider.Length, data );

                if( cbAuto.Checked && serialport.BaudRate == 300 ) {
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
                            serialport.BaudRate = baudrate;

                            baudRateToolStripStatusLabel.Text = serialport.BaudRate + "bps";
                        }
                    }
                }
            }
        }

        private void btnClear_Click( object sender, EventArgs e ) {
            dynamicByteProvider.DeleteBytes( 0, dynamicByteProvider.Length );
            hbSerialData.SelectionStart = 0;
            hbSerialData.SelectionLength = 0;
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

        private void NudBytePerLine_ValueChanged( object sender, EventArgs e ) {
            hbSerialData.BytesPerLine = Convert.ToInt32( nudBytePerLine.Value );
            nudGroupSize.Maximum = nudBytePerLine.Value;
        }

        private void NudGroupSize_ValueChanged( object sender, EventArgs e ) {
            hbSerialData.GroupSize = Convert.ToInt32( nudGroupSize.Value );
        }

        private void BtnSave_Click( object sender, EventArgs e ) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                Filter = "Text Files|*.txt"
            };

            if( saveFileDialog.ShowDialog() == DialogResult.OK ) {
                StreamWriter serialLog = new StreamWriter( saveFileDialog.FileName );

                serialLog.Write( log_data );
                serialLog.Close();
            }
        }

        private void BtnSaveHex_Click( object sender, EventArgs e ) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                Filter = "Text Files|*.txt"
            };

            if( saveFileDialog.ShowDialog() == DialogResult.OK ) {
                StreamWriter serialLog = new StreamWriter(saveFileDialog.FileName);

                byte[] data = dynamicByteProvider.Bytes.ToArray();
                string save = string.Empty;

                for( int i = 0; i < data.Length; i++ ) {
                    if( i != 0 && i % nudBytePerLine.Value == 0 ) {
                        save += "\r\n";
                    }
                    save += String.Format( "0x{0:X2}", data[ i ] ) + " ";
                }

                serialLog.Write( save.Substring(0, save.Length - 1 ));
                serialLog.Close();
            }
        }

        private void CopyAsHexToolStripMenuItem_Click( object sender, EventArgs e ) {
            byte[] buf = new byte[hbSerialData.SelectionLength];

            dynamicByteProvider.Bytes.CopyTo( Convert.ToInt32( hbSerialData.SelectionStart ), buf, 0, Convert.ToInt32( hbSerialData.SelectionLength ) );
            string save = string.Empty;

            for( int i = 0; i < buf.Length; i++ ) {
                if( i != 0 && i % nudBytePerLine.Value == 0 ) {
                    save += "\r\n";
                }
                save += String.Format( "0x{0:X2}", buf[ i ] ) + " ";
            }

            Clipboard.SetText( save );
        }

        private void CopyAsTextToolStripMenuItem_Click( object sender, EventArgs e ) {
            hbSerialData.Copy();
        }

        private void CopyAsBinaryToolStripMenuItem_Click( object sender, EventArgs e ) {
            byte[] buf = new byte[hbSerialData.SelectionLength];

            dynamicByteProvider.Bytes.CopyTo( Convert.ToInt32( hbSerialData.SelectionStart ), buf, 0, Convert.ToInt32( hbSerialData.SelectionLength ) );
            string save = string.Empty;

            for( int i = 0; i < buf.Length; i++ ) {
                if( i != 0 && i % nudBytePerLine.Value == 0 ) {
                    save += "\r\n";
                }
                save += buf[ i ] + " ";
            }

            Clipboard.SetText( save );
        }
    }

    public class csettings {
        public bool auto_baud_switch = true;
        public bool dtr = true;
        public bool rts = true;

        public int bytes_per_line = 16;
        public int group_size = 4;

        public string log_path = string.Empty;
        public string serial_port_name = string.Empty;
        public string baud_rate = string.Empty;
        public string data_bit = string.Empty;
        public string parity = string.Empty;
        public string stop_bit = string.Empty;

        public bool Get() {
            auto_baud_switch = Properties.Settings.Default.auto_baud_switch;
            dtr = Properties.Settings.Default.dtr;
            rts = Properties.Settings.Default.rts;

            bytes_per_line = Properties.Settings.Default.bytes_per_line;
            group_size = Properties.Settings.Default.group_size;

            serial_port_name = Properties.Settings.Default.serial_port_name;
            baud_rate = Properties.Settings.Default.baud_rate;
            data_bit = Properties.Settings.Default.data_bit;
            parity = Properties.Settings.Default.parity;
            stop_bit = Properties.Settings.Default.stop_bit;

            log_path = AppDomain.CurrentDomain.BaseDirectory + "log\\";

            return true;
        }

        public void Save() {
            Properties.Settings.Default.auto_baud_switch = auto_baud_switch;
            Properties.Settings.Default.dtr = dtr;
            Properties.Settings.Default.rts = rts;

            Properties.Settings.Default.bytes_per_line = bytes_per_line;
            Properties.Settings.Default.group_size = group_size;

            Properties.Settings.Default.serial_port_name = serial_port_name;
            Properties.Settings.Default.baud_rate = baud_rate;
            Properties.Settings.Default.data_bit = data_bit;
            Properties.Settings.Default.parity = parity;
            Properties.Settings.Default.stop_bit = stop_bit;

            Properties.Settings.Default.Save();
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
