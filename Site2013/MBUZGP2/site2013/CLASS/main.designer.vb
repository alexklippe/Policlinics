﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.18046
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="tgp2_site")>  _
Partial Public Class mainDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Определения метода расширяемости"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertOtdel(instance As Otdel)
    End Sub
  Partial Private Sub UpdateOtdel(instance As Otdel)
    End Sub
  Partial Private Sub DeleteOtdel(instance As Otdel)
    End Sub
  Partial Private Sub Insertfilials(instance As filials)
    End Sub
  Partial Private Sub Updatefilials(instance As filials)
    End Sub
  Partial Private Sub Deletefilials(instance As filials)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("tgp2_siteConnectionString").ConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property Otdel() As System.Data.Linq.Table(Of Otdel)
		Get
			Return Me.GetTable(Of Otdel)
		End Get
	End Property
	
	Public ReadOnly Property filials() As System.Data.Linq.Table(Of filials)
		Get
			Return Me.GetTable(Of filials)
		End Get
	End Property
	
	Public ReadOnly Property TelephoneOtdelov() As System.Data.Linq.Table(Of TelephoneOtdelov)
		Get
			Return Me.GetTable(Of TelephoneOtdelov)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Otdel")>  _
Partial Public Class Otdel
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _otdelName As String
	
	Private _cabinetNum As String
	
	Private _IDFilial As Integer
	
	Private _filials As EntityRef(Of filials)
	
    #Region "Определения метода расширяемости"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnidChanging(value As Integer)
    End Sub
    Partial Private Sub OnidChanged()
    End Sub
    Partial Private Sub OnotdelNameChanging(value As String)
    End Sub
    Partial Private Sub OnotdelNameChanged()
    End Sub
    Partial Private Sub OncabinetNumChanging(value As String)
    End Sub
    Partial Private Sub OncabinetNumChanged()
    End Sub
    Partial Private Sub OnIDFilialChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDFilialChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._filials = CType(Nothing, EntityRef(Of filials))
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me.OnidChanging(value)
				Me.SendPropertyChanging
				Me._id = value
				Me.SendPropertyChanged("id")
				Me.OnidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_otdelName", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property otdelName() As String
		Get
			Return Me._otdelName
		End Get
		Set
			If (String.Equals(Me._otdelName, value) = false) Then
				Me.OnotdelNameChanging(value)
				Me.SendPropertyChanging
				Me._otdelName = value
				Me.SendPropertyChanged("otdelName")
				Me.OnotdelNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_cabinetNum", DbType:="NVarChar(4)")>  _
	Public Property cabinetNum() As String
		Get
			Return Me._cabinetNum
		End Get
		Set
			If (String.Equals(Me._cabinetNum, value) = false) Then
				Me.OncabinetNumChanging(value)
				Me.SendPropertyChanging
				Me._cabinetNum = value
				Me.SendPropertyChanged("cabinetNum")
				Me.OncabinetNumChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDFilial", DbType:="Int NOT NULL")>  _
	Public Property IDFilial() As Integer
		Get
			Return Me._IDFilial
		End Get
		Set
			If ((Me._IDFilial = value)  _
						= false) Then
				If Me._filials.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnIDFilialChanging(value)
				Me.SendPropertyChanging
				Me._IDFilial = value
				Me.SendPropertyChanged("IDFilial")
				Me.OnIDFilialChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="filials_Otdel", Storage:="_filials", ThisKey:="IDFilial", OtherKey:="id", IsForeignKey:=true)>  _
	Public Property filials() As filials
		Get
			Return Me._filials.Entity
		End Get
		Set
			Dim previousValue As filials = Me._filials.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._filials.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._filials.Entity = Nothing
					previousValue.Otdel.Remove(Me)
				End If
				Me._filials.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.Otdel.Add(Me)
					Me._IDFilial = value.id
				Else
					Me._IDFilial = CType(Nothing, Integer)
				End If
				Me.SendPropertyChanged("filials")
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.filials")>  _
Partial Public Class filials
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _name As String
	
	Private _address As String
	
	Private _description As String
	
	Private _proezd As String
	
	Private _porjadokSortirovki As System.Nullable(Of Integer)
	
	Private _Otdel As EntitySet(Of Otdel)
	
    #Region "Определения метода расширяемости"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnidChanging(value As Integer)
    End Sub
    Partial Private Sub OnidChanged()
    End Sub
    Partial Private Sub OnnameChanging(value As String)
    End Sub
    Partial Private Sub OnnameChanged()
    End Sub
    Partial Private Sub OnaddressChanging(value As String)
    End Sub
    Partial Private Sub OnaddressChanged()
    End Sub
    Partial Private Sub OndescriptionChanging(value As String)
    End Sub
    Partial Private Sub OndescriptionChanged()
    End Sub
    Partial Private Sub OnproezdChanging(value As String)
    End Sub
    Partial Private Sub OnproezdChanged()
    End Sub
    Partial Private Sub OnporjadokSortirovkiChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnporjadokSortirovkiChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._Otdel = New EntitySet(Of Otdel)(AddressOf Me.attach_Otdel, AddressOf Me.detach_Otdel)
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me.OnidChanging(value)
				Me.SendPropertyChanging
				Me._id = value
				Me.SendPropertyChanged("id")
				Me.OnidChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_name", DbType:="NVarChar(100) NOT NULL", CanBeNull:=false)>  _
	Public Property name() As String
		Get
			Return Me._name
		End Get
		Set
			If (String.Equals(Me._name, value) = false) Then
				Me.OnnameChanging(value)
				Me.SendPropertyChanging
				Me._name = value
				Me.SendPropertyChanged("name")
				Me.OnnameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_address", DbType:="NVarChar(100) NOT NULL", CanBeNull:=false)>  _
	Public Property address() As String
		Get
			Return Me._address
		End Get
		Set
			If (String.Equals(Me._address, value) = false) Then
				Me.OnaddressChanging(value)
				Me.SendPropertyChanging
				Me._address = value
				Me.SendPropertyChanged("address")
				Me.OnaddressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_description", DbType:="NVarChar(1000)")>  _
	Public Property description() As String
		Get
			Return Me._description
		End Get
		Set
			If (String.Equals(Me._description, value) = false) Then
				Me.OndescriptionChanging(value)
				Me.SendPropertyChanging
				Me._description = value
				Me.SendPropertyChanged("description")
				Me.OndescriptionChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_proezd", DbType:="NVarChar(1000)")>  _
	Public Property proezd() As String
		Get
			Return Me._proezd
		End Get
		Set
			If (String.Equals(Me._proezd, value) = false) Then
				Me.OnproezdChanging(value)
				Me.SendPropertyChanging
				Me._proezd = value
				Me.SendPropertyChanged("proezd")
				Me.OnproezdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_porjadokSortirovki", DbType:="Int")>  _
	Public Property porjadokSortirovki() As System.Nullable(Of Integer)
		Get
			Return Me._porjadokSortirovki
		End Get
		Set
			If (Me._porjadokSortirovki.Equals(value) = false) Then
				Me.OnporjadokSortirovkiChanging(value)
				Me.SendPropertyChanging
				Me._porjadokSortirovki = value
				Me.SendPropertyChanged("porjadokSortirovki")
				Me.OnporjadokSortirovkiChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="filials_Otdel", Storage:="_Otdel", ThisKey:="id", OtherKey:="IDFilial")>  _
	Public Property Otdel() As EntitySet(Of Otdel)
		Get
			Return Me._Otdel
		End Get
		Set
			Me._Otdel.Assign(value)
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_Otdel(ByVal entity As Otdel)
		Me.SendPropertyChanging
		entity.filials = Me
	End Sub
	
	Private Sub detach_Otdel(ByVal entity As Otdel)
		Me.SendPropertyChanging
		entity.filials = Nothing
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.TelephoneOtdelov")>  _
Partial Public Class TelephoneOtdelov
	
	Private _id As Integer
	
	Private _idOtdel As Integer
	
	Private _telephoneNumber As String
	
	Private _Name As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_id", DbType:="Int NOT NULL")>  _
	Public Property id() As Integer
		Get
			Return Me._id
		End Get
		Set
			If ((Me._id = value)  _
						= false) Then
				Me._id = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_idOtdel", DbType:="Int NOT NULL")>  _
	Public Property idOtdel() As Integer
		Get
			Return Me._idOtdel
		End Get
		Set
			If ((Me._idOtdel = value)  _
						= false) Then
				Me._idOtdel = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_telephoneNumber", DbType:="NChar(15) NOT NULL", CanBeNull:=false)>  _
	Public Property telephoneNumber() As String
		Get
			Return Me._telephoneNumber
		End Get
		Set
			If (String.Equals(Me._telephoneNumber, value) = false) Then
				Me._telephoneNumber = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Name", DbType:="NVarChar(100)")>  _
	Public Property Name() As String
		Get
			Return Me._Name
		End Get
		Set
			If (String.Equals(Me._Name, value) = false) Then
				Me._Name = value
			End If
		End Set
	End Property
End Class