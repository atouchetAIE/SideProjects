﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Info;

namespace WinFormsLoggingSystem
{
    public partial class Log : Form
    {
        InfoHandler info = new InfoHandler();

        public Log()
        {
            InitializeComponent();
            if(File.Exists(Environment.CurrentDirectory + "/Contacts.xml"))
                info.instance.contacts = info.instance.ReadContacts();
            Open_Log(null, null);
        }

        private void SaveLog(object sender, EventArgs e)
        {
            var path = Environment.CurrentDirectory + "/SaveFile.xml";  
            File.WriteAllText(path, LogBox.Text);
            MessageBox.Show("File has been Saved!");
        }

        private void LoadLog(object sender, EventArgs e)
        {
            var path = Environment.CurrentDirectory + "/SaveFile.xml";
            LogBox.Text = File.ReadAllText(path);
        }

        private void Open_Contacts(object sender, EventArgs e)
        {
            //Log Window
            saveButton.Visible = false;
            loadButton.Visible = false;
            LogBox.Visible = false;

            //Contact Window
            saveContact.Visible = true;
            addNumber.Visible = true;
            contactNumber.Visible = true;
            contactName.Visible = true;
            nameLabel.Visible = true;
            numberLabel.Visible = true;
            contactInfo.Visible = true;
            contactLabel.Visible = true;
        }

        private void Open_Log(object sender, EventArgs e)
        {
            //Log Window
            LogBox.Visible = true;
            saveButton.Visible = true;
            loadButton.Visible = true;

            //Contact Window
            saveContact.Visible = false;
            addNumber.Visible = false;
            contactNumber.Visible = false;
            contactName.Visible = false;
            nameLabel.Visible = false;
            numberLabel.Visible = false;
            contactInfo.Visible = false;
            contactLabel.Visible = false;
        }

        private void Save_Contact(object sender, EventArgs e)
        {
            if (!info.instance.AddContact(contactName.Text, contactNumber.Text))
                MessageBox.Show("Contact Already Exists.");

            else
            {
                MessageBox.Show("Contact Saved!");
                info.instance.SaveContacts();
            }        
        }

        private void Add_Number(object sender, EventArgs e)
        {
            if (info.instance.AddNumer(contactName.Text, contactNumber.Text))
            {
                MessageBox.Show("Contact now has this number as well.");
                info.instance.SaveContacts();
            }
                
            else
                MessageBox.Show("Can't add number. Either contact exists or number already entered.");
        }
    }
}