using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Negocios;
using Dto;
using Correios.Net;

namespace Projeto
{
    public partial class frm_Graficos : Form
    {
        public frm_Graficos()
        {
            InitializeComponent();
        }
        private void carregaGrafico(int mes, decimal valor)
        {
            if(mes == 1)
            {
                chGrafico.Series["Valor"].Points.AddXY("Jan", valor);
            }
            else if(mes == 2)
            {
                chGrafico.Series["Valor"].Points.AddXY("Fev", valor);
            }
            else if (mes == 3)
            {
                chGrafico.Series["Valor"].Points.AddXY("Mar", valor);
            }
            else if (mes == 4)
            {
                chGrafico.Series["Valor"].Points.AddXY("Abr", valor);
            }
            else if (mes == 5)
            {
                chGrafico.Series["Valor"].Points.AddXY("Mai", valor);
            }
            else if (mes == 6)
            {
                chGrafico.Series["Valor"].Points.AddXY("Jun", valor);
            }
            else if (mes == 7)
            {
                chGrafico.Series["Valor"].Points.AddXY("Jul", valor);
            }
            else if (mes == 8)
            {
                chGrafico.Series["Valor"].Points.AddXY("Ago", valor);
            }
            else if (mes == 9)
            {
                chGrafico.Series["Valor"].Points.AddXY("Set", valor);
            }
            else if (mes == 10)
            {
                chGrafico.Series["Valor"].Points.AddXY("Out", valor);
            }
            else if (mes == 11)
            {
                chGrafico.Series["Valor"].Points.AddXY("Nov", valor);
            }
            else if (mes == 12)
            {
                chGrafico.Series["Valor"].Points.AddXY("Dez", valor);
            }
        }
        private int mesCarregamento(int mesNegativo)
        {
            int mesCorreto = 0;

            if(mesNegativo == -1)
            {
                mesCorreto = 12;
            }
            else if(mesNegativo == -2)
            {
                mesCorreto = 11;
            }
            else if(mesNegativo == -3)
            {
                mesCorreto = 9;
            }
            else if(mesNegativo == -4)
            {
                mesCorreto = 8;
            }
            else if(mesNegativo == -5)
            {
                mesCorreto = 7;
            }else if(mesNegativo == -6)
            {
                mesCorreto = 6;
            }
            else if(mesNegativo == -7)
            {
                mesCorreto = 5;
            }else if(mesNegativo == -8)
            {
                mesCorreto = 4;
            }

            return mesCorreto;
        }
        private void frm_Graficos_Load(object sender, EventArgs e)
        {
            VendaNegocio vendaNegocio = new VendaNegocio();
            int mes;
            decimal valor;

            mes = DateTime.Today.Date.Month;
            mes = mes - 9;
            
            if(mes < 0)
            {
                mes = mesCarregamento(mes);
            }

            for (int t = 0; t < 9; t++)
            {
                VendaColecao vendaMes = vendaNegocio.CarregaMes(mes);
                if (vendaMes.Count != 0)
                {
                    valor = vendaMes[0].Valor;
                }
                else
                {
                    valor = 0;
                }

                carregaGrafico(mes, valor);
                if (mes == 12)
                {
                    mes = 0;
                }
                mes++;
            }
        }
    }
}
