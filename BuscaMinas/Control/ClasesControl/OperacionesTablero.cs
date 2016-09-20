using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control.ClasesControl
{
   public class OperacionesTablero
    {
        
        int tamano, numminas;
       public OperacionesTablero() { }
        public OperacionesTablero(int minas,int tamano)
        {
           
            numminas = minas;
            this.tamano = tamano;
        }
        
        public int Obtenercantidadminas()
        {
            return numminas;
        }

        public int Obtenertamano()
        {
            return tamano;
        }
        
        public int CeldasValidas()
        {
            int celdas = (tamano * tamano) - numminas;
            return celdas;

        }

        

        public void ColocarMinas(PictureBox [,]Tablero)
        {
            //ponemos las minas aleatoriamente en el tablero 
            int contador = 0;
            Random r = new Random();
            while (contador < numminas)
            {
                int varX, varY;
                varX = r.Next(0, tamano);
                varY = r.Next(0, tamano);
                if (Tablero[varX, varY].Tag.ToString().Substring(0, 1).Equals("0"))
                {
                    Tablero[varX, varY].Tag = "1,"+varX+","+varY;
                    contador++;
                }
            }

        }

        public void terminaJuego(PictureBox[,]tablero,String mensaje)
        {
            MessageBox.Show(mensaje,"Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            string ruta = Application.StartupPath;
            for (int fila = 0; fila < tamano; fila++)
            {
                for (int col = 0; col < tamano; col++)
                {
                    tablero[fila, col].Enabled = false;
                   
                    if (tablero[fila,col].Tag.ToString().Substring(0,1).Equals("1"))
                    {
                        tablero[fila, col].Image = Image.FromFile(ruta + "/mina.jpg");//descubrimos todas las minas
                    }
                }
            }
            
        }

        


        public int contador_Minas_Alrededor(PictureBox[,]tableroaux,int x, int y)
        {
            int aux = 0;
            if (x == 0)
            {
                if (y == 0)
                {
                    if (tableroaux[x, y + 1].Tag.ToString().Substring(0,1).Equals("1"))
                        aux++;
                    if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                        aux++;
                    if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                        aux++;
                }
                else
                {
                    if (y == tamano - 1)
                    {
                        if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                    }
                    else
                    {
                        if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                    }
                }
            }
            else
            {
                if (x == tamano - 1)
                {
                    if (y == 0)
                    {
                        if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                    }
                    else
                    {
                        if (y == tamano - 1)
                        {
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                        }
                        else
                        {
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                        }
                    }
                }
                else
                {
                    if (y == 0)
                    {
                        //
                        if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                            aux++;
                        //
                    }
                    else
                    {
                        if (y ==tamano - 1)
                        {
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                        }
                        else
                        {
                            //
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("1")) 
                                aux++;
                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                            if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("1"))
                                aux++;
                        }
                    }
                }
            }
            return aux;
        }


        public void InHabilitar_casillas_alrededor(PictureBox[,] tableroaux, int x, int y)
        {
            string ruta = Application.StartupPath;
            int aux = contador_Minas_Alrededor(tableroaux,x,y);
            int celdas_validas = this.CeldasValidas();

            if (aux>=1)
            {
                tableroaux[x, y].Enabled = false;

            }else { 
                if (x == 0)
                {

                    if (y == 0)//esquina superior izquierda
                    {

                        if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))

                        {
                            
                            tableroaux[x, y + 1].Enabled = false;
                            
                        }


                        if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                        {
                            tableroaux[x + 1, y].Enabled = false;
                            
                        }

                        if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                        {

                            
                            tableroaux[x + 1, y + 1].Enabled = false;
                            
                        }

                    }
                    else
                    {
                        if (y == tamano - 1)//esquina superior derecha
                        {
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x, y - 1].Enabled = false;
                                                 
                            

                            if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x + 1, y].Enabled = false;
                                                           

                            if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x + 1, y - 1].Enabled = false;
                                
                            
                        }
                        else//validaciones parte superior x=0
                        {
                            if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x, y - 1].Enabled = false;
                               
                            

                            if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x + 1, y].Enabled = false;
                               
                            

                            if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x + 1, y - 1].Enabled = false;
                               
                            

                            if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x + 1, y + 1].Enabled = false;
                                
                            

                            if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))

                            
                                tableroaux[x, y + 1].Enabled = false;
                                
                            
                        }
                    }
                }
                else
                {
                    if (x == tamano - 1)
                    {
                        if (y == 0)//esquina inferior izquierda
                        {
                            if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x, y + 1].Enabled = false;
                                
                            

                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y].Enabled = false;
                                
                            

                            if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y + 1].Enabled = false;
                                
                            
                        }
                        else
                        {
                            if (y == tamano - 1)//esquina inferior derecha
                            {
                                if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x, y - 1].Enabled = false;
                                
                                

                                if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x - 1, y].Enabled = false;
                                
                                

                                if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x - 1, y - 1].Enabled = false;
                                
                                
                            }
                            else
                            {//validaciones parte inferior
                                if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x, y - 1].Enabled = false;
                                
                                

                                if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x - 1, y].Enabled = false;
                                   
                                

                                if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x - 1, y - 1].Enabled = false;
                                   
                                

                                if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x, y + 1].Enabled = false;
                                   
                                

                                if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                    tableroaux[x, y + 1].Enabled = false;
                                   
                                
                            }
                        }
                    }
                    else
                    {

                        if (y == 0)
                        {//validaciones lado izquierdo

                            if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                            tableroaux[x, y + 1].Enabled = false;
                           
                            

                            if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                            tableroaux[x - 1, y].Enabled = false;
                            
                            

                            if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                            tableroaux[x - 1, y + 1].Enabled = false;
                          
                            

                            if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                            tableroaux[x + 1, y].Enabled = false;
                          
                            

                            if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                            tableroaux[x + 1, y + 1].Enabled = false;
                          
                            
                           
                        }
                        else
                        {//validaciones lado derecho
                            if (y == tamano - 1)
                            {
                                if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x, y - 1].Enabled = false;



                                if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y].Enabled = false;



                                if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y - 1].Enabled = false;



                                if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x + 1, y].Enabled = false;



                                if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x + 1, y - 1].Enabled = false;


                            }
                            else
                            {
                                //validacion para una posicion dentro del tablero
                                if (tableroaux[x, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x, y - 1].Enabled = false;



                                if (tableroaux[x - 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y].Enabled = false;



                                if (tableroaux[x - 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x - 1, y - 1].Enabled = false;



                                if (tableroaux[x + 1, y].Tag.ToString().Substring(0, 1).Equals("0"))
                            
                                tableroaux[x + 1, y].Enabled = false;



                                if (tableroaux[x + 1, y - 1].Tag.ToString().Substring(0, 1).Equals("0"))
                                
                                tableroaux[x + 1, y - 1].Enabled = false;



                                if (tableroaux[x - 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                                    
                                tableroaux[x - 1, y + 1].Enabled = false;



                                if (tableroaux[x, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                                    
                                tableroaux[x, y + 1].Enabled = false;




                                if (tableroaux[x + 1, y + 1].Tag.ToString().Substring(0, 1).Equals("0"))
                                    
                                tableroaux[x + 1, y + 1].Enabled = false;

                            } 
                            
                        }
                    }
                }


            }
            
            //return total;
        }

        public int contceldas_inhabilitadas(PictureBox[,]tablero)
        {
          
            int cont=0;
           
            for (int fila = 0; fila < tamano; fila++)
            {
                for (int col = 0; col < tamano; col++)
                {
                    if (tablero[fila, col].Enabled.Equals(false))
                    {
                        cont++;
                    }

                }
            }
            return cont;
            
                

            }

        }

    }

