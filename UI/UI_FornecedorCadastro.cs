using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogin.UI
{
    public static class UI_FornecedorCadastro
    {
        // cores
        public static readonly Color CorPrimaria = Color.FromArgb(139, 90, 43);           // #8B5A2B Marrom
        public static readonly Color CorPrimariaClara = Color.FromArgb(210, 180, 140);    // #D2B48C Bege claro
        public static readonly Color CorFundo = Color.FromArgb(245, 235, 220);            // #F5EBDC Bege muito claro
        public static readonly Color CorTexto = Color.FromArgb(62, 39, 35);               // #3E2723 Marrom escuro
        public static readonly Color CorTextoMudo = Color.FromArgb(120, 100, 85);         // Cinza marrom
        public static readonly Color CorDestaque = Color.FromArgb(205, 133, 63);          // #CD853F Marrom bronze
        public static readonly Color CorSucesso = Color.FromArgb(76, 175, 80);            // Verde
        public static readonly Color CorDanger = Color.FromArgb(220, 53, 69);             // Vermelho
        public static readonly Color CorAviso = Color.FromArgb(255, 152, 0);              // Laranja

        // fontes
        public static readonly Font FontTitulo = new Font("Segoe UI", 20, FontStyle.Bold);
        public static readonly Font FontSubtitulo = new Font("Segoe UI", 11, FontStyle.Regular);
        public static readonly Font FontSecao = new Font("Segoe UI", 12, FontStyle.Bold);
        public static readonly Font FontLabel = new Font("Segoe UI", 9, FontStyle.Bold);
        public static readonly Font FontCampo = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font FontBotao = new Font("Segoe UI", 10, FontStyle.Bold);
        public static readonly Font FontStatus = new Font("Segoe UI", 9, FontStyle.Regular);

        // dimensões
        public static readonly int HeaderHeight = 85;
        public static readonly int ToolbarHeight = 55;
        public static readonly int FooterHeight = 40;
        public static readonly int EspacoSecao = 50;
        public static readonly int EspacoCampo = 70;
        public static readonly int AlturaCampo = 30;
        public static readonly int Padding = 20;
    }
}
