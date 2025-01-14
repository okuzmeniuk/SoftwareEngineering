﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.DAL.Entities
{
    public class Product : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public DateTime LastUpdated { get; set; }

        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
