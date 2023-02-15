﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EIgnacioBabelEntities : DbContext
    {
        public EIgnacioBabelEntities()
            : base("name=EIgnacioBabelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cobertura> Coberturas { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
    
        public virtual int ClienteAdd(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idPlanes, Nullable<int> idCobertura)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idPlanesParameter = idPlanes.HasValue ?
                new ObjectParameter("IdPlanes", idPlanes) :
                new ObjectParameter("IdPlanes", typeof(int));
    
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClienteAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idPlanesParameter, idCoberturaParameter);
        }
    
        public virtual int ClienteDelete(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClienteDelete", idClienteParameter);
        }
    
        public virtual ObjectResult<ClienteGetAll_Result> ClienteGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClienteGetAll_Result>("ClienteGetAll");
        }
    
        public virtual ObjectResult<ClienteGetById_Result> ClienteGetById(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ClienteGetById_Result>("ClienteGetById", idClienteParameter);
        }
    
        public virtual int ClienteUpdate(Nullable<int> idCliente, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idPlanes, Nullable<int> idCobertura)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("IdCliente", idCliente) :
                new ObjectParameter("IdCliente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idPlanesParameter = idPlanes.HasValue ?
                new ObjectParameter("IdPlanes", idPlanes) :
                new ObjectParameter("IdPlanes", typeof(int));
    
            var idCoberturaParameter = idCobertura.HasValue ?
                new ObjectParameter("IdCobertura", idCobertura) :
                new ObjectParameter("IdCobertura", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClienteUpdate", idClienteParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idPlanesParameter, idCoberturaParameter);
        }
    
        public virtual ObjectResult<CoberturaGetAll_Result> CoberturaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CoberturaGetAll_Result>("CoberturaGetAll");
        }
    
        public virtual int PlanesAdd(string descripcion)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlanesAdd", descripcionParameter);
        }
    
        public virtual ObjectResult<PlanesGetAll_Result> PlanesGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PlanesGetAll_Result>("PlanesGetAll");
        }
    
        public virtual ObjectResult<PlanesGetById_Result> PlanesGetById(Nullable<int> idPlanes)
        {
            var idPlanesParameter = idPlanes.HasValue ?
                new ObjectParameter("IdPlanes", idPlanes) :
                new ObjectParameter("IdPlanes", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PlanesGetById_Result>("PlanesGetById", idPlanesParameter);
        }
    
        public virtual int PlanesUpdate(Nullable<int> idPlanes, string descripcion)
        {
            var idPlanesParameter = idPlanes.HasValue ?
                new ObjectParameter("IdPlanes", idPlanes) :
                new ObjectParameter("IdPlanes", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PlanesUpdate", idPlanesParameter, descripcionParameter);
        }
    }
}
