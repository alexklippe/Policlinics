Public Class MainClass


    Shared Function GetOrgId(ByVal requesturl As System.Web.HttpRequest) As Integer

        Dim db As New mainDataContext
        Dim query = From p In db.Organization Where p.OrgDomainName = requesturl.Url.Host Or p.OrgTestDomainName = requesturl.Url.Host
        Return query.First.id
    End Function

    
End Class
