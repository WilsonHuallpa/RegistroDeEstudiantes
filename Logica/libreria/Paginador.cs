﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.libreria
{
    public class Paginador<T>
    {
        private List<T> _dataList;
        private Label _label;
        private static int maxReg, _reg_por_pagina, pageCount, numPagi = 1;

        public Paginador(List<T> dataList, Label label, int reg_por_pagina)
        {
            this._dataList = dataList;
            this._label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }
        private void cargarDatos()
        {
            numPagi = 1;
            maxReg = _dataList.Count;
            pageCount = (maxReg / _reg_por_pagina);

            if ((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 0;
            }
            _label.Text = $"Paginas 1 / {pageCount}";

        }
        public int primero()
        {
            numPagi = 1;
            _label.Text = $"Paginas {numPagi} / {pageCount}";
            return numPagi;
        }
        public int anterior()
        {
            if (numPagi > 1)
            {
                numPagi -= 1;
                _label.Text = $"Paginas {numPagi} / {pageCount}";
            }
            return numPagi;
        }
        public int siguiente()
        {
            if (numPagi == pageCount)
            {
                numPagi -= 1;
            }
            if (numPagi < pageCount)
            {
                numPagi += 1;
                _label.Text = $"Paginas {numPagi} / {pageCount}";
            }
            return numPagi;
        }
        public int ultimo()
        {
            numPagi = pageCount;
            _label.Text = $"Paginas {numPagi} / {pageCount}";
            return numPagi;
        }
    }

}
