var users = [];

$(document).ready(function() {
	$.ajax({
    url : 'https://localhost:7215/Contacts/GetUserContacts',
    type : 'GET',
    dataType:'json',
	
    success : function(data) {
		this.users = data;
		this.users.forEach(u => {
			$("#list-of-contacts").append("<li>" + u.name + "<button onclick='deleteUser(" + u.id + ")'>delete user</button></li>");
		});
    },
    error : function(request,error)
    {
        // alert("Request: "+JSON.stringify(request));
    }
	});
	
	$("#createUserForm").submit(function(event) {
		createUser();
	});
});

function createUser() {
	var contact = {
			type: $("#userTypeCnt").val(),
			value: $("#userValueCnt").val()
		};
		var createUserData = {
			name: $("#userName").val(),
			contacts: [contact]
		};
		
		$.ajax({
			url : 'https://localhost:7215/Contacts/CreateUser',
			type : 'POST',
			data : JSON.stringify({
				"name": $("#userName").val(),
				"contacts": [{
					"type": $("#userTypeCnt").val(),
					"value": $("#userValueCnt").val()
				}]
			}),
			dataType: "json",
			contentType: "application/json",
			success : function(data) {
				alert('Success!');
			},
			error : function(request,error)
			{
				alert("Error: "+JSON.stringify(request));
			}
		});
}

function deleteUser(id) {
	$.ajax({
		url : 'https://localhost:7215/Contacts/DeleteUser/' + id,
		type : 'DELETE',
		success : function(data) {              
			alert('Success!');
		},
		error : function(request,error)
		{
			alert("Request: "+JSON.stringify(request));
		}
	});
}