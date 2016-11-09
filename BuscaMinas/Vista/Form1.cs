using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control.ClasesControl;
namespace Vista
{
    public partial class ventana : Form
    {
        public ventana()
        {
            InitializeComponent();
            DateTime.Now.ToString("D");
           
            lblhora_fecha.Text ="dia:"+ DateTime.Now.ToString("D")+" Hora:"+DateTime.Now.ToString("hh:mm:ss tt");
        }
        OperacionesTablero tab;
        PictureBox[,] TableroPrincipal;
        Label etiqueta;

        int tamano = 0;
        int  minas = 0;




        private void btnjugar_Click(object sender, EventArgs e)
        {
            if (txttamano.Text.Equals("") || txtminas.Text.Equals(""))
            {
                MessageBox.Show("Lo sentimos ingrese el tamaño y numero de minas con las que desea jugar!!", "Ingrese los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                tamano = int.Parse(txttamano.Text);
                minas = int.Parse(txtminas.Text);
                txtminas.Enabled = false;
                txttamano.Enabled = false;
                btnjugar.Enabled = false;

                if (tamano > 10 || minas > 15)
                {
                    MessageBox.Show("Lo sentimos considere un tamaño diferente menor o igual a 10!!!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtminas.Enabled = true;
                    txttamano.Enabled = true;
                    btnjugar.Enabled = true;
                }
                else
                {

                    TableroPrincipal = new PictureBox[tamano, tamano];
                    tab = new OperacionesTablero(minas, tamano);
                    this.CrearTablero();
                    paneltablero.Visible = true;



                }

            }
        }
        public void CrearTablero()
        {
          

                    for (int fila = 0; fila < tamano; fila++)
                    {
                        for (int col = 0; col < tamano; col++)
                        {
                            TableroPrincipal[fila, col] = new PictureBox();//creamos un nuevo objeto PictureBox
                            TableroPrincipal[fila, col].BackColor = Color.Gray;
                            TableroPrincipal[fila, col].Width = 35;//ancho
                            TableroPrincipal[fila, col].Height = 35;//alto
                            TableroPrincipal[fila, col].Location = new Point(40 * fila, 40 * col);//posicion en el tablero
                            TableroPrincipal[fila, col].Tag = "0," + fila + "," + col;//etiqueta con numero de mina,fila,columna de ubicacion
                            TableroPrincipal[fila, col].SizeMode = PictureBoxSizeMode.StretchImage;
                            TableroPrincipal[fila, col].MouseClick += new MouseEventHandler(Casilla_Click);//evento dado un clic en la caja
                           
                            paneltablero.Controls.Add(TableroPrincipal[fila, col]);
                        }

                    }


            
                    tab.ColocarMinas(TableroPrincipal);//colocamos las minas en el tablero

               
            
        }


        public void Casilla_Click(object sender, EventArgs e)
        {
            int auxtamano = tab.Obtenertamano();
            int auxminas = tab.Obtenercantidadminas();
            string ruta = Application.StartupPath;
            
            PictureBox casilla = (PictureBox)sender;

            if (casilla.Tag.ToString().Substring(0, 1).Equals("1"))
            {

                casilla.Image = Image.FromFile(ruta + "/mina.jpg");
                tab.terminaJuego(TableroPrincipal, "has Perdido, pisaste una mina!!!");
                String posy = casilla.Tag.ToString().Substring(2, 1);
                string posx = casilla.Tag.ToString().Substring(4, 1);
                MessageBox.Show("posicion x :"+posx +" posicion en y: "+posy,"Ubicacion");
                txtminas.Enabled = true;
                txttamano.Enabled = true;
                btnjugar.Enabled = true;

                txtminas.Text = "";
                txttamano.Text = "";
                paneltablero.Controls.Clear();
                paneltablero.Visible = false;
                
                                               
            }
            else
            {
                casilla.Enabled = false;
                int fila = int.Parse(casilla.Tag.ToString().Substring(2, 1));
                int col = int.Parse(casilla.Tag.ToString().Substring(4,1));
               
                int minasalrededor = tab.contador_Minas_Alrededor(TableroPrincipal,fila,col);
                etiqueta = new Label();
                etiqueta.Text = minasalrededor.ToString();//label que muestra el num de minas alrededor
               
                
                etiqueta.Location = new Point(casilla.Location.X, casilla.Location.Y);
                etiqueta.Parent = TableroPrincipal[1, 1];
                etiqueta.Width = 35;
                etiqueta.Height = 35;
                etiqueta.BackColor = Color.White;
                paneltablero.Controls.Add(etiqueta);
                
               casilla.Visible = false;


                tab.InHabilitar_casillas_alrededor(TableroPrincipal,fila,col);

                for (int i = 0; i < tab.Obtenertamano(); i++)
                {
                    for (int j = 0; j <tab.Obtenertamano(); j++)
                    {
                                             
                        if (TableroPrincipal[i,j].Enabled==false && !TableroPrincipal[i,j].Tag.ToString().Substring(0,1).Equals("1"))
                        {
                            int resaux=tab.contador_Minas_Alrededor(TableroPrincipal,i,j);
                            Label aux = new Label();
                            aux.Text = resaux.ToString();//label que muestra el num de minas alrededor


                            aux.Location = new Point(TableroPrincipal[i,j].Location.X, TableroPrincipal[i,j].Location.Y);
                            aux.Parent = TableroPrincipal[1, 1];
                            aux.Width = 35;
                            aux.Height = 35;
                            aux.BackColor = Color.White;
                            paneltablero.Controls.Add(aux);
                            TableroPrincipal[i, j].Visible = false;
                           
                        }
                    }
                }

                int totalceldas=tab.CeldasValidas();
                int celdas_inhabilitadas = tab.contceldas_inhabilitadas(TableroPrincipal);
            
                if (totalceldas==celdas_inhabilitadas)
                {
                    tab.terminaJuego(TableroPrincipal,"GANASTE, Descubriste la ubicacion de las minas !!!");
                    MessageBox.Show("esta es la Ubicacion de las minas en el tablero \n Descubriendo minas...!!","Notificacion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    txtminas.Enabled = true;
                    txttamano.Enabled = true;
                    btnjugar.Enabled = true;

                    txtminas.Text = "";
                    txttamano.Text = "";
                    paneltablero.Controls.Clear();
                    paneltablero.Visible = false;
                }

            }
        }
        
    }
}
