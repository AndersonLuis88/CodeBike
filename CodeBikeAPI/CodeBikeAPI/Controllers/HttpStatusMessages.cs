using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBikeAPI.Controllers
{
    /// Mensagens de retorno HTTP
    public static class HttpStatusMessages
    {   /// A entidade foi criada.
        public const string Created = "A entidade foi criada.";

        /// Operação completada com sucesso.
        public const string OkAction = "Operação completada com sucesso.";

        /// A entidade foi atualizada.
        public const string OkUpdate = "A entidade foi atualizada.";

        /// Entidade deletada ou não existe
        public const string OkDelete = "Entidade deletada ou não existe";

        /// Sobre a Entidade.
        public const string OkGet = "Sobre a Entidade.";

        /// Sobre as Entidades.
        public const string OkList = "Sobre as Entidades.";

        /// A entidade não existe.
        public const string NotFound = "A entidade não existe.";

        /// <summary>
        /// Dados inválidos ou ausentes.
        /// </summary>
        public const string BadRequest = "Dados inválidos ou ausentes.";

    }
}

