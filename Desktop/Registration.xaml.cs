﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            Manager.InputSystem = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrentWindow.Show();
            this.Close();
        }

        private void InAccount_Click(object sender, RoutedEventArgs e)
        {
            var validName = Validator.NameValid(NameBox.Text);
            var validMail = Validator.MailValid(MailBox.Text);
            var validPass = Validator.PassValid(PasswordBox.Text);
            var replayPass = Validator.ComparisonPass(PasswordBox.Text, ReplayPasswordBox.Text);
            if (validName == null)
            {
                if (validMail == true)
                {
                    if (validPass == null)
                    {
                        if (replayPass == null)
                        {
                            var wind = new MainEmpty();
                            wind.Show();
                            Manager.InputSystem.Close();
                            Manager.CurrentWindow.Close();
                        }
                        else
                        {
                            MessageBox.Show(replayPass);
                        }
                    }
                    else
                    {
                        MessageBox.Show(validPass);
                    }
                }
                else
                {
                    MessageBox.Show("Неверная форма ввода почты");
                }
            }
            else
            {
                MessageBox.Show(validName);
            }
        }
    }
}
