using System;
using System.Collections.Generic;
using Domain.Entidades;

namespace Domain.DTO
{
    public class UsuariosPaginadosDTO : List<Usuario>
    {
        protected UsuariosPaginadosDTO(){}

        public UsuariosPaginadosDTO(List<Usuario> items, long total, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            AddRange(items);
        }

        public int TotalPages { get; }
        public int PageIndex { get; }
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
    }
}