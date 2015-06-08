
create view view_user_rol_post_comments as
select DISTINCT AspNetUsers.Id, AspNetUsers.UserName, AspNetUsers.realname, AspNetRoles.Name as 'rol', 
	(select count(*) from tbl_post where tbl_post.idPublisher = AspNetUsers.Id) as 'post', 
	(select count(*) from tbl_comment where tbl_comment.idUser = AspNetUsers.Id) as 'comments'
from  AspNetUsers, AspNetRoles, AspNetUserRoles
where 
	  AspNetUserRoles.UserId = AspNetUsers.Id and
	  AspNetRoles.Id = AspNetUserRoles.RoleId and
	  AspNetRoles.Name != 'SuperAdmin' and 
	  AspNetUsers.UserName != 'NoRegistrado'


