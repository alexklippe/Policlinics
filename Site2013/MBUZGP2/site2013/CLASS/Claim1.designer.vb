﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.34209
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
Partial Public Class ClaimDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Определения метода расширяемости"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertClaims(instance As Claims)
    End Sub
  Partial Private Sub UpdateClaims(instance As Claims)
    End Sub
  Partial Private Sub DeleteClaims(instance As Claims)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.System.Configuration.ConfigurationManager.ConnectionStrings("tgp2_siteConnectionString1").ConnectionString, mappingSource)
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
	
	Public ReadOnly Property Claims() As System.Data.Linq.Table(Of Claims)
		Get
			Return Me.GetTable(Of Claims)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Claims")>  _
Partial Public Class Claims
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _id As Integer
	
	Private _UserName As String
	
	Private _UserEMail As String
	
	Private _UserContact As String
	
	Private _UserAddress As String
	
	Private _UserText As String
	
	Private _UserAddedFiles As String
	
	Private _CreateDateTime As System.Nullable(Of Date)
	
	Private _answeresDateTime As System.Nullable(Of Date)
	
	Private _LastEditTime As System.Nullable(Of Date)
	
	Private _del As System.Nullable(Of Boolean)
	
	Private _Filial As System.Nullable(Of Integer)
	
	Private _Title As String
	
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
    Partial Private Sub OnUserNameChanging(value As String)
    End Sub
    Partial Private Sub OnUserNameChanged()
    End Sub
    Partial Private Sub OnUserEMailChanging(value As String)
    End Sub
    Partial Private Sub OnUserEMailChanged()
    End Sub
    Partial Private Sub OnUserContactChanging(value As String)
    End Sub
    Partial Private Sub OnUserContactChanged()
    End Sub
    Partial Private Sub OnUserAddressChanging(value As String)
    End Sub
    Partial Private Sub OnUserAddressChanged()
    End Sub
    Partial Private Sub OnUserTextChanging(value As String)
    End Sub
    Partial Private Sub OnUserTextChanged()
    End Sub
    Partial Private Sub OnUserAddedFilesChanging(value As String)
    End Sub
    Partial Private Sub OnUserAddedFilesChanged()
    End Sub
    Partial Private Sub OnCreateDateTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnCreateDateTimeChanged()
    End Sub
    Partial Private Sub OnansweresDateTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnansweresDateTimeChanged()
    End Sub
    Partial Private Sub OnLastEditTimeChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnLastEditTimeChanged()
    End Sub
    Partial Private Sub OndelChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OndelChanged()
    End Sub
    Partial Private Sub OnFilialChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnFilialChanged()
    End Sub
    Partial Private Sub OnTitleChanging(value As String)
    End Sub
    Partial Private Sub OnTitleChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserName", DbType:="NVarChar(255)")>  _
	Public Property UserName() As String
		Get
			Return Me._UserName
		End Get
		Set
			If (String.Equals(Me._UserName, value) = false) Then
				Me.OnUserNameChanging(value)
				Me.SendPropertyChanging
				Me._UserName = value
				Me.SendPropertyChanged("UserName")
				Me.OnUserNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserEMail", DbType:="NVarChar(255)")>  _
	Public Property UserEMail() As String
		Get
			Return Me._UserEMail
		End Get
		Set
			If (String.Equals(Me._UserEMail, value) = false) Then
				Me.OnUserEMailChanging(value)
				Me.SendPropertyChanging
				Me._UserEMail = value
				Me.SendPropertyChanged("UserEMail")
				Me.OnUserEMailChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserContact", DbType:="NVarChar(255)")>  _
	Public Property UserContact() As String
		Get
			Return Me._UserContact
		End Get
		Set
			If (String.Equals(Me._UserContact, value) = false) Then
				Me.OnUserContactChanging(value)
				Me.SendPropertyChanging
				Me._UserContact = value
				Me.SendPropertyChanged("UserContact")
				Me.OnUserContactChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserAddress", DbType:="NVarChar(300)")>  _
	Public Property UserAddress() As String
		Get
			Return Me._UserAddress
		End Get
		Set
			If (String.Equals(Me._UserAddress, value) = false) Then
				Me.OnUserAddressChanging(value)
				Me.SendPropertyChanging
				Me._UserAddress = value
				Me.SendPropertyChanged("UserAddress")
				Me.OnUserAddressChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserText", DbType:="NVarChar(3000)")>  _
	Public Property UserText() As String
		Get
			Return Me._UserText
		End Get
		Set
			If (String.Equals(Me._UserText, value) = false) Then
				Me.OnUserTextChanging(value)
				Me.SendPropertyChanging
				Me._UserText = value
				Me.SendPropertyChanged("UserText")
				Me.OnUserTextChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserAddedFiles", DbType:="NVarChar(255)")>  _
	Public Property UserAddedFiles() As String
		Get
			Return Me._UserAddedFiles
		End Get
		Set
			If (String.Equals(Me._UserAddedFiles, value) = false) Then
				Me.OnUserAddedFilesChanging(value)
				Me.SendPropertyChanging
				Me._UserAddedFiles = value
				Me.SendPropertyChanged("UserAddedFiles")
				Me.OnUserAddedFilesChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreateDateTime", DbType:="DateTime")>  _
	Public Property CreateDateTime() As System.Nullable(Of Date)
		Get
			Return Me._CreateDateTime
		End Get
		Set
			If (Me._CreateDateTime.Equals(value) = false) Then
				Me.OnCreateDateTimeChanging(value)
				Me.SendPropertyChanging
				Me._CreateDateTime = value
				Me.SendPropertyChanged("CreateDateTime")
				Me.OnCreateDateTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_answeresDateTime", DbType:="DateTime")>  _
	Public Property answeresDateTime() As System.Nullable(Of Date)
		Get
			Return Me._answeresDateTime
		End Get
		Set
			If (Me._answeresDateTime.Equals(value) = false) Then
				Me.OnansweresDateTimeChanging(value)
				Me.SendPropertyChanging
				Me._answeresDateTime = value
				Me.SendPropertyChanged("answeresDateTime")
				Me.OnansweresDateTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LastEditTime", DbType:="DateTime")>  _
	Public Property LastEditTime() As System.Nullable(Of Date)
		Get
			Return Me._LastEditTime
		End Get
		Set
			If (Me._LastEditTime.Equals(value) = false) Then
				Me.OnLastEditTimeChanging(value)
				Me.SendPropertyChanging
				Me._LastEditTime = value
				Me.SendPropertyChanged("LastEditTime")
				Me.OnLastEditTimeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_del", DbType:="Bit")>  _
	Public Property del() As System.Nullable(Of Boolean)
		Get
			Return Me._del
		End Get
		Set
			If (Me._del.Equals(value) = false) Then
				Me.OndelChanging(value)
				Me.SendPropertyChanging
				Me._del = value
				Me.SendPropertyChanged("del")
				Me.OndelChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Filial", DbType:="Int")>  _
	Public Property Filial() As System.Nullable(Of Integer)
		Get
			Return Me._Filial
		End Get
		Set
			If (Me._Filial.Equals(value) = false) Then
				Me.OnFilialChanging(value)
				Me.SendPropertyChanging
				Me._Filial = value
				Me.SendPropertyChanged("Filial")
				Me.OnFilialChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Title", DbType:="NVarChar(200)")>  _
	Public Property Title() As String
		Get
			Return Me._Title
		End Get
		Set
			If (String.Equals(Me._Title, value) = false) Then
				Me.OnTitleChanging(value)
				Me.SendPropertyChanging
				Me._Title = value
				Me.SendPropertyChanged("Title")
				Me.OnTitleChanged
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
