Public Class mainModule
    Public Function GetFilialInfo(Optional ByVal id As Integer = 1) As List(Of String)
        Dim a As New List(Of String)
        Dim db As New ContactsDataContext
        Dim query = From p In db.filials Where p.id = id Select p
        If query.Count = 0 Then
            id = 1
            query = From p In db.filials Where p.id = id Select p
        End If
        a.Add(query.First.name) 'название филиала
        a.Add(query.First.address) 'адрес
        a.Add(query.First.WorkTime) 'рабочее время 
        a.Add(query.First.proezd) 'проезд 

        Dim query2 = From p In db.Sotrudnikis Where p.id = query.First.idRukovoditel Select p
        a.Add(query2.First.Surname + " " + query2.First.Name + " " + query2.First.MidName)

        Dim query3 = From p In db.Cabinets Join p2 In db.filials On p2.idCabinetRukovoditelya Equals p.id Where p2.id = id Select p


        a.Add(query3.First.cabinetNum) 'номер кабиета
        a.Add(query3.First.cabinetTel) 'номер телефона
        Try
            Dim query4 = From p In db.Cabinets Join p2 In db.filials On p2.idTelRegistratur Equals p.id Where p2.id = id Select p

            a.Add(query4.First.cabinetTel) ' тел регистратуры
        Catch ex As Exception
            a.Add("-") ' тел регистратуры
        End Try

       
        Return a
    End Function

End Class
