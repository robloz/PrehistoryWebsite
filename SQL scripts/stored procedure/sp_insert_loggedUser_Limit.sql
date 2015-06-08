

create  procedure sp_insert_loggedUser_Limit
(
	@idUser nvarchar(128),
	@limit int,
	@id int OUT
)
as
begin
	/* check how many users are in */
	if (select count(*) from tbl_loggedUser where idUser=@idUser)>=@limit
		begin

			Declare @idFirstLogged int;
			select @idFirstLogged = A.id 
			from tbl_loggedUser A
			where
				logged = 
				(
					select min(logged)
					from tbl_loggedUser B
					where A.idUser = B.idUser 
				)
			/* delete the last record*/
			delete from tbl_loggedUser where id=@idFirstLogged
		end

		/* insert the new record*/
			insert into tbl_loggedUser(idUser) values(@idUser)
			/* get the last record or the user */
			select @id = A.id 
			from tbl_loggedUser A
			where
				logged = 
				(
					select max(logged)
					from tbl_loggedUser B
					where A.idUser = B.idUser 
				)
end
