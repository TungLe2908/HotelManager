﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagerApi.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="alo895cb_congnghemoi")]
	public partial class HotelEntitiesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAccount(Account instance);
    partial void UpdateAccount(Account instance);
    partial void DeleteAccount(Account instance);
    partial void InsertRoomType(RoomType instance);
    partial void UpdateRoomType(RoomType instance);
    partial void DeleteRoomType(RoomType instance);
    partial void InsertBooking(Booking instance);
    partial void UpdateBooking(Booking instance);
    partial void DeleteBooking(Booking instance);
    partial void InsertBookingDetail(BookingDetail instance);
    partial void UpdateBookingDetail(BookingDetail instance);
    partial void DeleteBookingDetail(BookingDetail instance);
    partial void InsertPermission(Permission instance);
    partial void UpdatePermission(Permission instance);
    partial void DeletePermission(Permission instance);
    partial void InsertRoom(Room instance);
    partial void UpdateRoom(Room instance);
    partial void DeleteRoom(Room instance);
    partial void InsertRoomFeature(RoomFeature instance);
    partial void UpdateRoomFeature(RoomFeature instance);
    partial void DeleteRoomFeature(RoomFeature instance);
    #endregion
		
		public HotelEntitiesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["alo895cb_congnghemoiConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HotelEntitiesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HotelEntitiesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HotelEntitiesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HotelEntitiesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Account> Accounts
		{
			get
			{
				return this.GetTable<Account>();
			}
		}
		
		public System.Data.Linq.Table<RoomType> RoomTypes
		{
			get
			{
				return this.GetTable<RoomType>();
			}
		}
		
		public System.Data.Linq.Table<Booking> Bookings
		{
			get
			{
				return this.GetTable<Booking>();
			}
		}
		
		public System.Data.Linq.Table<BookingDetail> BookingDetails
		{
			get
			{
				return this.GetTable<BookingDetail>();
			}
		}
		
		public System.Data.Linq.Table<Permission> Permissions
		{
			get
			{
				return this.GetTable<Permission>();
			}
		}
		
		public System.Data.Linq.Table<Room> Rooms
		{
			get
			{
				return this.GetTable<Room>();
			}
		}
		
		public System.Data.Linq.Table<RoomFeature> RoomFeatures
		{
			get
			{
				return this.GetTable<RoomFeature>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.Account")]
	public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _AccountID;
		
		private string _AccountName;
		
		private string _AccountEmail;
		
		private string _AccountPhone;
		
		private string _AccountPassword;
		
		private string _PermissionID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccountIDChanging(string value);
    partial void OnAccountIDChanged();
    partial void OnAccountNameChanging(string value);
    partial void OnAccountNameChanged();
    partial void OnAccountEmailChanging(string value);
    partial void OnAccountEmailChanged();
    partial void OnAccountPhoneChanging(string value);
    partial void OnAccountPhoneChanged();
    partial void OnAccountPasswordChanging(string value);
    partial void OnAccountPasswordChanged();
    partial void OnPermissionIDChanging(string value);
    partial void OnPermissionIDChanged();
    #endregion
		
		public Account()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string AccountID
		{
			get
			{
				return this._AccountID;
			}
			set
			{
				if ((this._AccountID != value))
				{
					this.OnAccountIDChanging(value);
					this.SendPropertyChanging();
					this._AccountID = value;
					this.SendPropertyChanged("AccountID");
					this.OnAccountIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountName", DbType="NVarChar(50)")]
		public string AccountName
		{
			get
			{
				return this._AccountName;
			}
			set
			{
				if ((this._AccountName != value))
				{
					this.OnAccountNameChanging(value);
					this.SendPropertyChanging();
					this._AccountName = value;
					this.SendPropertyChanged("AccountName");
					this.OnAccountNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountEmail", DbType="NVarChar(50)")]
		public string AccountEmail
		{
			get
			{
				return this._AccountEmail;
			}
			set
			{
				if ((this._AccountEmail != value))
				{
					this.OnAccountEmailChanging(value);
					this.SendPropertyChanging();
					this._AccountEmail = value;
					this.SendPropertyChanged("AccountEmail");
					this.OnAccountEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountPhone", DbType="NVarChar(15)")]
		public string AccountPhone
		{
			get
			{
				return this._AccountPhone;
			}
			set
			{
				if ((this._AccountPhone != value))
				{
					this.OnAccountPhoneChanging(value);
					this.SendPropertyChanging();
					this._AccountPhone = value;
					this.SendPropertyChanged("AccountPhone");
					this.OnAccountPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountPassword", DbType="NVarChar(25)")]
		public string AccountPassword
		{
			get
			{
				return this._AccountPassword;
			}
			set
			{
				if ((this._AccountPassword != value))
				{
					this.OnAccountPasswordChanging(value);
					this.SendPropertyChanging();
					this._AccountPassword = value;
					this.SendPropertyChanged("AccountPassword");
					this.OnAccountPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PermissionID", DbType="NVarChar(25)")]
		public string PermissionID
		{
			get
			{
				return this._PermissionID;
			}
			set
			{
				if ((this._PermissionID != value))
				{
					this.OnPermissionIDChanging(value);
					this.SendPropertyChanging();
					this._PermissionID = value;
					this.SendPropertyChanged("PermissionID");
					this.OnPermissionIDChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.RoomType")]
	public partial class RoomType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _RoomTypeID;
		
		private string _RoomTypeName;
		
		private string _ListFeatures;
		
		private System.Nullable<int> _Price;
		
		private System.Nullable<int> _NoPeople;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoomTypeIDChanging(string value);
    partial void OnRoomTypeIDChanged();
    partial void OnRoomTypeNameChanging(string value);
    partial void OnRoomTypeNameChanged();
    partial void OnListFeaturesChanging(string value);
    partial void OnListFeaturesChanged();
    partial void OnPriceChanging(System.Nullable<int> value);
    partial void OnPriceChanged();
    partial void OnNoPeopleChanging(System.Nullable<int> value);
    partial void OnNoPeopleChanged();
    #endregion
		
		public RoomType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomTypeID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string RoomTypeID
		{
			get
			{
				return this._RoomTypeID;
			}
			set
			{
				if ((this._RoomTypeID != value))
				{
					this.OnRoomTypeIDChanging(value);
					this.SendPropertyChanging();
					this._RoomTypeID = value;
					this.SendPropertyChanged("RoomTypeID");
					this.OnRoomTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomTypeName", DbType="NVarChar(50)")]
		public string RoomTypeName
		{
			get
			{
				return this._RoomTypeName;
			}
			set
			{
				if ((this._RoomTypeName != value))
				{
					this.OnRoomTypeNameChanging(value);
					this.SendPropertyChanging();
					this._RoomTypeName = value;
					this.SendPropertyChanged("RoomTypeName");
					this.OnRoomTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListFeatures", DbType="NVarChar(200)")]
		public string ListFeatures
		{
			get
			{
				return this._ListFeatures;
			}
			set
			{
				if ((this._ListFeatures != value))
				{
					this.OnListFeaturesChanging(value);
					this.SendPropertyChanging();
					this._ListFeatures = value;
					this.SendPropertyChanged("ListFeatures");
					this.OnListFeaturesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int")]
		public System.Nullable<int> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoPeople", DbType="Int")]
		public System.Nullable<int> NoPeople
		{
			get
			{
				return this._NoPeople;
			}
			set
			{
				if ((this._NoPeople != value))
				{
					this.OnNoPeopleChanging(value);
					this.SendPropertyChanging();
					this._NoPeople = value;
					this.SendPropertyChanged("NoPeople");
					this.OnNoPeopleChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.Booking")]
	public partial class Booking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _BookingID;
		
		private string _AccountID;
		
		private System.Nullable<System.DateTime> _BookingDate;
		
		private System.Nullable<System.DateTime> _ReceivingDate;
		
		private System.Nullable<bool> _BookingStatus;
		
		private System.Nullable<int> _Quantity;
		
		private string _Others;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookingIDChanging(string value);
    partial void OnBookingIDChanged();
    partial void OnAccountIDChanging(string value);
    partial void OnAccountIDChanged();
    partial void OnBookingDateChanging(System.Nullable<System.DateTime> value);
    partial void OnBookingDateChanged();
    partial void OnReceivingDateChanging(System.Nullable<System.DateTime> value);
    partial void OnReceivingDateChanged();
    partial void OnBookingStatusChanging(System.Nullable<bool> value);
    partial void OnBookingStatusChanged();
    partial void OnQuantityChanging(System.Nullable<int> value);
    partial void OnQuantityChanged();
    partial void OnOthersChanging(string value);
    partial void OnOthersChanged();
    #endregion
		
		public Booking()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string BookingID
		{
			get
			{
				return this._BookingID;
			}
			set
			{
				if ((this._BookingID != value))
				{
					this.OnBookingIDChanging(value);
					this.SendPropertyChanging();
					this._BookingID = value;
					this.SendPropertyChanged("BookingID");
					this.OnBookingIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountID", DbType="NVarChar(25)")]
		public string AccountID
		{
			get
			{
				return this._AccountID;
			}
			set
			{
				if ((this._AccountID != value))
				{
					this.OnAccountIDChanging(value);
					this.SendPropertyChanging();
					this._AccountID = value;
					this.SendPropertyChanged("AccountID");
					this.OnAccountIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> BookingDate
		{
			get
			{
				return this._BookingDate;
			}
			set
			{
				if ((this._BookingDate != value))
				{
					this.OnBookingDateChanging(value);
					this.SendPropertyChanging();
					this._BookingDate = value;
					this.SendPropertyChanged("BookingDate");
					this.OnBookingDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReceivingDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ReceivingDate
		{
			get
			{
				return this._ReceivingDate;
			}
			set
			{
				if ((this._ReceivingDate != value))
				{
					this.OnReceivingDateChanging(value);
					this.SendPropertyChanging();
					this._ReceivingDate = value;
					this.SendPropertyChanged("ReceivingDate");
					this.OnReceivingDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingStatus", DbType="Bit")]
		public System.Nullable<bool> BookingStatus
		{
			get
			{
				return this._BookingStatus;
			}
			set
			{
				if ((this._BookingStatus != value))
				{
					this.OnBookingStatusChanging(value);
					this.SendPropertyChanging();
					this._BookingStatus = value;
					this.SendPropertyChanged("BookingStatus");
					this.OnBookingStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Others", DbType="NVarChar(500)")]
		public string Others
		{
			get
			{
				return this._Others;
			}
			set
			{
				if ((this._Others != value))
				{
					this.OnOthersChanging(value);
					this.SendPropertyChanging();
					this._Others = value;
					this.SendPropertyChanged("Others");
					this.OnOthersChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.BookingDetail")]
	public partial class BookingDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _BookingID;
		
		private string _RoomID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookingIDChanging(string value);
    partial void OnBookingIDChanged();
    partial void OnRoomIDChanging(string value);
    partial void OnRoomIDChanged();
    #endregion
		
		public BookingDetail()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookingID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string BookingID
		{
			get
			{
				return this._BookingID;
			}
			set
			{
				if ((this._BookingID != value))
				{
					this.OnBookingIDChanging(value);
					this.SendPropertyChanging();
					this._BookingID = value;
					this.SendPropertyChanged("BookingID");
					this.OnBookingIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string RoomID
		{
			get
			{
				return this._RoomID;
			}
			set
			{
				if ((this._RoomID != value))
				{
					this.OnRoomIDChanging(value);
					this.SendPropertyChanging();
					this._RoomID = value;
					this.SendPropertyChanged("RoomID");
					this.OnRoomIDChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.Permission")]
	public partial class Permission : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _PermissionID;
		
		private System.Nullable<int> _PermissionLevel;
		
		private string _PermissionName;
		
		private string _Token;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPermissionIDChanging(string value);
    partial void OnPermissionIDChanged();
    partial void OnPermissionLevelChanging(System.Nullable<int> value);
    partial void OnPermissionLevelChanged();
    partial void OnPermissionNameChanging(string value);
    partial void OnPermissionNameChanged();
    partial void OnTokenChanging(string value);
    partial void OnTokenChanged();
    #endregion
		
		public Permission()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PermissionID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string PermissionID
		{
			get
			{
				return this._PermissionID;
			}
			set
			{
				if ((this._PermissionID != value))
				{
					this.OnPermissionIDChanging(value);
					this.SendPropertyChanging();
					this._PermissionID = value;
					this.SendPropertyChanged("PermissionID");
					this.OnPermissionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PermissionLevel", DbType="Int")]
		public System.Nullable<int> PermissionLevel
		{
			get
			{
				return this._PermissionLevel;
			}
			set
			{
				if ((this._PermissionLevel != value))
				{
					this.OnPermissionLevelChanging(value);
					this.SendPropertyChanging();
					this._PermissionLevel = value;
					this.SendPropertyChanged("PermissionLevel");
					this.OnPermissionLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PermissionName", DbType="NVarChar(50)")]
		public string PermissionName
		{
			get
			{
				return this._PermissionName;
			}
			set
			{
				if ((this._PermissionName != value))
				{
					this.OnPermissionNameChanging(value);
					this.SendPropertyChanging();
					this._PermissionName = value;
					this.SendPropertyChanged("PermissionName");
					this.OnPermissionNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Token", DbType="NVarChar(255)")]
		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				if ((this._Token != value))
				{
					this.OnTokenChanging(value);
					this.SendPropertyChanging();
					this._Token = value;
					this.SendPropertyChanged("Token");
					this.OnTokenChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.Room")]
	public partial class Room : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _RoomID;
		
		private string _RoomTypeID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoomIDChanging(string value);
    partial void OnRoomIDChanged();
    partial void OnRoomTypeIDChanging(string value);
    partial void OnRoomTypeIDChanged();
    #endregion
		
		public Room()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string RoomID
		{
			get
			{
				return this._RoomID;
			}
			set
			{
				if ((this._RoomID != value))
				{
					this.OnRoomIDChanging(value);
					this.SendPropertyChanging();
					this._RoomID = value;
					this.SendPropertyChanged("RoomID");
					this.OnRoomIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomTypeID", DbType="NVarChar(25)")]
		public string RoomTypeID
		{
			get
			{
				return this._RoomTypeID;
			}
			set
			{
				if ((this._RoomTypeID != value))
				{
					this.OnRoomTypeIDChanging(value);
					this.SendPropertyChanging();
					this._RoomTypeID = value;
					this.SendPropertyChanged("RoomTypeID");
					this.OnRoomTypeIDChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="alo895cb_congnghemoi.RoomFeature")]
	public partial class RoomFeature : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _FeatureID;
		
		private string _FeatureName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFeatureIDChanging(string value);
    partial void OnFeatureIDChanged();
    partial void OnFeatureNameChanging(string value);
    partial void OnFeatureNameChanged();
    #endregion
		
		public RoomFeature()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FeatureID", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string FeatureID
		{
			get
			{
				return this._FeatureID;
			}
			set
			{
				if ((this._FeatureID != value))
				{
					this.OnFeatureIDChanging(value);
					this.SendPropertyChanging();
					this._FeatureID = value;
					this.SendPropertyChanged("FeatureID");
					this.OnFeatureIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FeatureName", DbType="NVarChar(50)")]
		public string FeatureName
		{
			get
			{
				return this._FeatureName;
			}
			set
			{
				if ((this._FeatureName != value))
				{
					this.OnFeatureNameChanging(value);
					this.SendPropertyChanging();
					this._FeatureName = value;
					this.SendPropertyChanged("FeatureName");
					this.OnFeatureNameChanged();
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
