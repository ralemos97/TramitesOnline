using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.interfaces
{
    public interface IPerSolicitante
    {
        void AgregarSolicitante(Solicitante solicitante);
        Solicitante BuscarSolicitante(string documento);
    }
}
