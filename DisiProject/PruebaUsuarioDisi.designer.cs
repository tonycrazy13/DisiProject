﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisiProject
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DisiUser")]
	public partial class PruebaUsuarioDisiDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
    #endregion
		
		public PruebaUsuarioDisiDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DisiUserConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaUsuarioDisiDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaUsuarioDisiDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaUsuarioDisiDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaUsuarioDisiDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Usuario> Usuarios
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuarios")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _UsuarioEmpleado;
		
		private string _NombreEmpleado;
		
		private string _Contraseña;
		
		private string _Correo;
		
		private string _FechaContraseña;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUsuarioEmpleadoChanging(string value);
    partial void OnUsuarioEmpleadoChanged();
    partial void OnNombreEmpleadoChanging(string value);
    partial void OnNombreEmpleadoChanged();
    partial void OnContraseñaChanging(string value);
    partial void OnContraseñaChanged();
    partial void OnCorreoChanging(string value);
    partial void OnCorreoChanged();
    partial void OnFechaContraseñaChanging(string value);
    partial void OnFechaContraseñaChanged();
    #endregion
		
		public Usuario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UsuarioEmpleado", DbType="VarChar(50)")]
		public string UsuarioEmpleado
		{
			get
			{
				return this._UsuarioEmpleado;
			}
			set
			{
				if ((this._UsuarioEmpleado != value))
				{
					this.OnUsuarioEmpleadoChanging(value);
					this.SendPropertyChanging();
					this._UsuarioEmpleado = value;
					this.SendPropertyChanged("UsuarioEmpleado");
					this.OnUsuarioEmpleadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NombreEmpleado", DbType="VarChar(100)")]
		public string NombreEmpleado
		{
			get
			{
				return this._NombreEmpleado;
			}
			set
			{
				if ((this._NombreEmpleado != value))
				{
					this.OnNombreEmpleadoChanging(value);
					this.SendPropertyChanging();
					this._NombreEmpleado = value;
					this.SendPropertyChanged("NombreEmpleado");
					this.OnNombreEmpleadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Contraseña", DbType="VarChar(20)")]
		public string Contraseña
		{
			get
			{
				return this._Contraseña;
			}
			set
			{
				if ((this._Contraseña != value))
				{
					this.OnContraseñaChanging(value);
					this.SendPropertyChanging();
					this._Contraseña = value;
					this.SendPropertyChanged("Contraseña");
					this.OnContraseñaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Correo", DbType="NVarChar(50)")]
		public string Correo
		{
			get
			{
				return this._Correo;
			}
			set
			{
				if ((this._Correo != value))
				{
					this.OnCorreoChanging(value);
					this.SendPropertyChanging();
					this._Correo = value;
					this.SendPropertyChanged("Correo");
					this.OnCorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FechaContraseña", DbType="NVarChar(50)")]
		public string FechaContraseña
		{
			get
			{
				return this._FechaContraseña;
			}
			set
			{
				if ((this._FechaContraseña != value))
				{
					this.OnFechaContraseñaChanging(value);
					this.SendPropertyChanging();
					this._FechaContraseña = value;
					this.SendPropertyChanged("FechaContraseña");
					this.OnFechaContraseñaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591