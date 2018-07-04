using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class UsuariosPaginadosViewModel
    {
        public List<UsuarioViewModel> Items { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}