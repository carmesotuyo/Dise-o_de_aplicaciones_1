﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class OrdenarPeliculas : UserControl
    {
        private MenuAdmin _menuAdmin;
        public OrdenarPeliculas(MenuAdmin menuAdmin)
        {
            InitializeComponent();
            _menuAdmin = menuAdmin;
        }
    }
}