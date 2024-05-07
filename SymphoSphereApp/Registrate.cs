using SymphoSphereApp.DTOs;
using SymphoSphereApp.Services;
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
    public partial class Registrate : Form
    {
        UserService userService;
        public Registrate()
        {
            InitializeComponent();
            userService = new UserService();

        }

        private void Registrate_Load(object sender, EventArgs e)
        {

        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            RegistrateDto registrateDto = new RegistrateDto();
            registrateDto.Username = guna2TextBox1.Text;
            registrateDto.Pass = guna2TextBox2.Text;
            registrateDto.Email = guna2TextBox3.Text;

            RegistrateDtoValidator validationRules = new RegistrateDtoValidator();
            if (validationRules.Validate(registrateDto).IsValid)
            {
                if (await userService.GetUserByName(registrateDto.Username) == null)
                {
                    await userService.Registrate(registrateDto);
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(validationRules.Validate(registrateDto).Errors.FirstOrDefault().ErrorMessage);

            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
