using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebApi.Utils
{
    public enum CodigoErro
    {
        ItemEhPropriedadeRequerida,
        ItemIDEmUso,
        RecordNotFound,
        NaoFoiPossivelCriarItem,
        NaoFoiPossivelAtualizarItem,
        NaoFoiPossivelDeletarItem
    }
}
