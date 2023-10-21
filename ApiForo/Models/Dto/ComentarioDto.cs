﻿using System.ComponentModel.DataAnnotations;

namespace ApiForo.Models.Dto;

public class ComentarioDto
{
    public int Id { get; set; }
    [Required (ErrorMessage = "El contenido es requerido")]
    public string Contenido { get; set; }
    public bool Editado { get; set; }
    public int?  ComentarioPadreId { get; set; }
    public Comentario ComentarioPadre { get; set; }
    public ICollection<Comentario> Hijos { get; set; } = null;
}