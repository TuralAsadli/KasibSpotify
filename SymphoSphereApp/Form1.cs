using AutoMapper;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using NAudio.Wave;
using SymphoSphereApp.DTOs;
using SymphoSphereApp.Entities;
using SymphoSphereApp.Services;
using SymphoSphereApp.Utilities;
using System.Numerics;

namespace SymphoSphereApp
{
    public partial class Form1 : Form
    {
        UserService userService;
        SongService songService;
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        //List<Song> songList;
        public Form1()
        {

            InitializeComponent();
            Registrate registrate = new Registrate();
            registrate.Show();

            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader("C:\\Users\\Tural\\Downloads\\Bir yazıq uşaq Grunge.mp3");
            songService = new SongService();
            userService = new UserService();

            panel9.Controls.Clear();
        }



        private Color activeBackGroundColour = Color.FromArgb(52, 52, 52);
        private Color activeForeGroundColour = Color.FromArgb(47, 180, 90);

        private Color defouldBackGroundColour = Color.FromArgb(46, 46, 50);
        private Color defouldForeGroundColour = Color.FromArgb(200, 200, 200);

        bool draging = false;
        Point dragCursor;
        Point dragFrom;




        private void SetButtonColour(IconButton button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.IconColor = foreColor;


        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            //var song = await songService.GetAll();

            //int yPos = 45;


            //foreach (var item in song)
            //{

            //    Panel nameLabel = new Panel();
            //    nameLabel.Location = new Point(30, yPos);
            //    nameLabel.Size = new Size(512, 84);
            //    nameLabel.BackColor = Color.Red;
            //    nameLabel.Text = item.Name.ToString();
            //    nameLabel.AutoSize = true;
            //    panel9.Controls.Add(nameLabel);


            //    IconButton iconButtonName = new IconButton();
            //    iconButtonName.Dock = DockStyle.Left;
            //    iconButtonName.Size = new Size(244, 84);
            //    iconButtonName.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
            //    iconButtonName.ForeColor = System.Drawing.Color.FromArgb(200,200,200);
            //    iconButtonName.Text = item.Name;
            //    nameLabel.Controls.Add(iconButtonName);


            //    PictureBox pictureBox = new PictureBox();
            //    pictureBox.Dock = DockStyle.Left;
            //    pictureBox.ImageLocation = item.Path;
            //    pictureBox.Size = new Size(84, 84);
            //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //    nameLabel.Controls.Add(pictureBox);

            //    IconButton iconButtonDuration = new IconButton();
            //    iconButtonDuration.Dock = DockStyle.Right;
            //    iconButtonDuration.Size = new Size(94, 84);
            //    iconButtonDuration.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
            //    iconButtonDuration.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            //    iconButtonDuration.Text = item.Duration.ToString();
            //    nameLabel.Controls.Add(iconButtonDuration);

            //    IconButton iconButton = new IconButton();
            //    iconButton.Dock = DockStyle.Right;
            //    iconButton.Size = new Size(84, 84);
            //    iconButton.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
            //    iconButton.Text = "";
            //    iconButton.IconChar = IconChar.Play;
            //    iconButton.IconColor = System.Drawing.Color.FromArgb(200, 200, 200);
            //    iconButton.Tag = item;
            //    iconButton.Enabled = true;
            //    iconButton.Click += addonClickEvent;
            //    nameLabel.Controls.Add(iconButton);

            //    yPos += 30;
            //}

        }

        private void ItemButtonClickEventHandler(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            GetSongDto item = (GetSongDto)button.Tag;


            MessageBox.Show($"Item clicked: ID={item.Id}, Name={item.Name}");
        }

        private async void addOnClickEvent(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GetSongDto item = (GetSongDto)button.Tag;

            var song = await songService.GetSongById(item.Id);

            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            audioFileReader.Dispose();

            waveOutDevice = new WaveOut();
            //audioFileReader = new AudioFileReader("C:\\Users\\Tural\\Downloads\\Bir yazıq uşaq Grunge.mp3");
            audioFileReader = new AudioFileReader(song.FilePath);
            waveOutDevice.Volume = 0.1f;

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();


        }

        private async void addOnClickLikedEvent(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Song item = (Song)button.Tag;


            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            audioFileReader.Dispose();

            waveOutDevice = new WaveOut();
            //audioFileReader = new AudioFileReader("C:\\Users\\Tural\\Downloads\\Bir yazıq uşaq Grunge.mp3");
            audioFileReader = new AudioFileReader(item.FilePath);
            waveOutDevice.Volume = 0.1f;

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }


        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            SetButtonColour(button, activeBackGroundColour, activeForeGroundColour);

            panel9.Controls.Clear();

            var song = await songService.GetAll();

            int yPos = 45;


            foreach (var item in song)
            {
                Panel nameLabel = new Panel();
                nameLabel.Location = new Point(30, yPos);
                nameLabel.Size = new Size(512, 84);
                nameLabel.BackColor = Color.FromArgb(46, 46, 50);
                nameLabel.Text = item.Name.ToString();
                nameLabel.AutoSize = true;
                panel9.Controls.Add(nameLabel);


                IconButton iconButtonName = new IconButton();
                iconButtonName.Dock = DockStyle.Left;
                iconButtonName.Size = new Size(244, 84);
                iconButtonName.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButtonName.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButtonName.Tag = item;
                iconButtonName.Click += addSongToLiked;
                iconButtonName.Text = item.Name;
                iconButtonName.FlatAppearance.BorderSize = 0;
                iconButtonName.FlatStyle = FlatStyle.Flat;
                nameLabel.Controls.Add(iconButtonName);


                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Left;
                pictureBox.ImageLocation = item.Path;
                pictureBox.Size = new Size(84, 84);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                nameLabel.Controls.Add(pictureBox);

                IconButton iconButtonDuration = new IconButton();
                iconButtonDuration.Dock = DockStyle.Right;
                iconButtonDuration.Size = new Size(94, 84);
                iconButtonDuration.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButtonDuration.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButtonDuration.Text = item.Duration.ToString();
                iconButtonDuration.FlatAppearance.BorderSize = 0;
                iconButtonDuration.FlatStyle = FlatStyle.Flat;
                nameLabel.Controls.Add(iconButtonDuration);

                IconButton iconButton = new IconButton();
                iconButton.Dock = DockStyle.Right;
                iconButton.Size = new Size(84, 84);
                iconButton.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButton.Text = "";
                iconButton.IconChar = IconChar.Play;
                iconButton.IconColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButton.Tag = item;
                iconButton.Enabled = true;
                iconButton.FlatAppearance.BorderSize = 0;
                iconButton.FlatStyle = FlatStyle.Flat;
                iconButton.Click += addOnClickEvent;
                nameLabel.Controls.Add(iconButton);

                yPos += 90;
            }

            SetButtonColour(iconButton2, defouldBackGroundColour, defouldForeGroundColour);
            SetButtonColour(iconButton3, defouldBackGroundColour, defouldForeGroundColour);


        }

        private async void addSongToLiked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GetSongDto item = (GetSongDto)button.Tag;

            GetSongDto getSongDto = (GetSongDto)button.Tag;

            var song = await songService.GetSongById(getSongDto.Id);
            var user = JsonSerialise.DeserializeUserData();
            await userService.AddSongToUser(user.Id, song);

        }




        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void iconButton2_Click(object sender, EventArgs e)
        {


            IconButton button = (IconButton)sender;
            SetButtonColour(button, activeBackGroundColour, activeForeGroundColour);

            panel9.Controls.Clear();

            var userdto = JsonSerialise.DeserializeUserData();
            var user = await userService.GetUserWithSongs(userdto.Id);

            int yPos = 45;


            foreach (var item in user.Songs)
            {

                Panel nameLabel = new Panel();
                nameLabel.Location = new Point(30, yPos);
                nameLabel.Size = new Size(512, 84);
                nameLabel.BackColor = Color.FromArgb(46, 46, 50);
                nameLabel.Text = item.Name.ToString();
                nameLabel.AutoSize = true;
                panel9.Controls.Add(nameLabel);


                IconButton iconButtonName = new IconButton();
                iconButtonName.Dock = DockStyle.Left;
                iconButtonName.Size = new Size(244, 84);
                iconButtonName.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButtonName.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButtonName.Text = item.Name;
                iconButtonName.FlatAppearance.BorderSize = 0;
                iconButtonName.FlatStyle = FlatStyle.Flat;
                nameLabel.Controls.Add(iconButtonName);


                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Left;
                pictureBox.ImageLocation = item.Path;
                pictureBox.Size = new Size(84, 84);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                nameLabel.Controls.Add(pictureBox);

                IconButton iconButtonDuration = new IconButton();
                iconButtonDuration.Dock = DockStyle.Right;
                iconButtonDuration.Size = new Size(94, 84);
                iconButtonDuration.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButtonDuration.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButtonDuration.Text = item.Duration.ToString();
                iconButtonDuration.FlatAppearance.BorderSize = 0;
                iconButtonDuration.FlatStyle = FlatStyle.Flat;
                nameLabel.Controls.Add(iconButtonDuration);

                IconButton iconButton = new IconButton();
                iconButton.Dock = DockStyle.Right;
                iconButton.Size = new Size(84, 84);
                iconButton.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
                iconButton.Text = "";
                iconButton.IconChar = IconChar.Play;
                iconButton.IconColor = System.Drawing.Color.FromArgb(200, 200, 200);
                iconButton.Tag = item;
                iconButton.Enabled = true;
                iconButton.FlatAppearance.BorderSize = 0;
                iconButton.FlatStyle = FlatStyle.Flat;
                iconButton.Click += addOnClickLikedEvent;
                nameLabel.Controls.Add(iconButton);

                yPos += 90;
            }

            SetButtonColour(iconButton1, defouldBackGroundColour, defouldForeGroundColour);
            SetButtonColour(iconButton3, defouldBackGroundColour, defouldForeGroundColour);


        }



        private void iconButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

            IconButton button = (IconButton)sender;
            SetButtonColour(button, activeBackGroundColour, activeForeGroundColour);


            SetButtonColour(iconButton1, defouldBackGroundColour, defouldForeGroundColour);
            SetButtonColour(iconButton2, defouldBackGroundColour, defouldForeGroundColour);

            panel9.Controls.Clear();

            TextBox button1 = new TextBox();
            button1.Location = new Point(50, 300);
            button1.Name = "TextBoxName";
            panel9.Controls.Add(button1);

            TextBox button2 = new TextBox();
            button2.Location = new Point(250, 300);
            button2.Name = "TextBoxPath";
            panel9.Controls.Add(button2);



            Song song = new Song();
            song.Duration = TimeSpan.FromSeconds(55);
            song.Explicit = false;
            song.Name = button1.Text;
            song.Path = button2.Text;
            ;
            IconButton button3 = new IconButton();
            button3.Location = new Point(263, 341);
            button3.Text = "Send";
            button3.Tag = song;
            button3.Click += SendFileEventHandle;
            panel9.Controls.Add(button3);
        }




        public async void SendFileEventHandle(object sender, EventArgs e)
        {
            Song song = new Song();
            song.Duration = TimeSpan.FromSeconds(55);
            song.Explicit = false;
            foreach (Control item in panel9.Controls)
            {

                if (item.Name == "TextBoxName")
                {
                    song.Name = item.Text;
                }
                if (item.Name == "TextBoxPath")
                {
                    song.Path = item.Text;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                string projectDirectory = "E:\\Projects\\SymphoSphereApp\\SymphoSphereApp\\Files\\";

                string destinationFilePath = Path.Combine(projectDirectory, Path.GetFileName(selectedFilePath));

                File.Copy(selectedFilePath, destinationFilePath);

                IconButton btn = (IconButton)sender;
                //song.Name = openFileDialog.FileName;
                song.FilePath = destinationFilePath;

                await songService.CreateSong(song);

                MessageBox.Show("File has been saved to: " + destinationFilePath);

            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draging = true;
            dragCursor = Cursor.Position;
            dragFrom = this.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draging = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draging)
            {
                Point point = Point.Subtract(Cursor.Position, new Size(dragCursor));
                this.Location = Point.Add(dragFrom, new Size(point));
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.Name = "NevBtn";

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton7_Click(object sender, EventArgs e)
        {

            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            audioFileReader.Dispose();

            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader("C:\\Users\\Tural\\Downloads\\Bir yazıq uşaq Grunge.mp3");

            waveOutDevice.Volume = 0.1f;

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();




            //else
            //{
            //    waveOutDevice.Dispose();

            //    waveOutDevice = new WaveOut();
            //    waveOutDevice.Init(audioFileReader);
            //    waveOutDevice.Play();
            //}

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void iconButton11_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            guna2TrackBar1 = (Guna2TrackBar)sender;
            waveOutDevice.Volume = (float)guna2TrackBar1.Value / 100;

        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            if (waveOutDevice.PlaybackState == PlaybackState.Paused)
            {
                iconButton12.IconChar = IconChar.Pause;
                waveOutDevice.Play();
            }
            else
            {
                iconButton12.IconChar = IconChar.Play;
                waveOutDevice.Pause();
            }
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {

        }
    }
}