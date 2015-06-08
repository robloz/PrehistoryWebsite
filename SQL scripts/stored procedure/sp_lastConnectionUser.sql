create procedure sp_lastConnectionUser
(
	@userName nvarchar(128),
	@lastConnection datetime out
)
as
begin

	select @lastConnection = A.logged 
	from tbl_loggedUser A, dbo.AspNetUsers
	where
		AspNetUsers.UserName=@userName and
		AspNetUsers.Id = A.idUser and
		logged = 
					(
						select max(logged)
						from tbl_loggedUser B
						where A.idUser = B.idUser 
					)
end


