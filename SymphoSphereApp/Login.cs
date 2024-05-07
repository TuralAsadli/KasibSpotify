using Guna.UI2.WinForms;
using SymphoSphereApp.Configs;
using SymphoSphereApp.DTOs;
using SymphoSphereApp.Services;
using SymphoSphereApp.Utilities;
using SymphoSphereApp.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymphoSphereApp
{
    public partial class Login : Form
    {
        UserService userService;
        public Login()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            LoginDto loginDto = new LoginDto();
            loginDto.Username = guna2TextBox1.Text;
            loginDto.Pass = guna2TextBox2.Text;

            LoginDtoValidator validationRules = new LoginDtoValidator();
            if (validationRules.Validate(loginDto).IsValid)
            {
                var user = await userService.GetUserByName(loginDto.Username);
                if (user != null)
                {
                    UserDataDto userDataDto = new UserDataDto() { UserName = user.Name, Id = user.Id };
                    userDataDto.ResetJson();
                    userDataDto.WriteToFile();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect UserName or Password");
                }

            }
            else
            {
                MessageBox.Show(validationRules.Validate(loginDto).Errors.FirstOrDefault().ErrorMessage);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //private void iconButton1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
