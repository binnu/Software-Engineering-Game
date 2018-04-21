<?php
session_start();

require_once("UserController.php");
$uc = new UserController();

// if (isset($_POST['register']) && !empty($_POST['email']) && !empty($_POST['password'])){

	$username = $_POST['username'];
	$password = $_POST['password'];
	$semester = $_POST['semester'];
	$studentId = $_POST['studentId'];
	$email = $_POST['email'];

	$password_hashed = password_hash($password, PASSWORD_DEFAULT);
	$checkUserExistence = $uc->ifUserExists($username , $email);
if(!$checkUserExistence){
 $result = $uc->insertUser($username,$password_hashed,$semester,$studentId,$email);
 echo "Registered succesfully";
 error_log("success");
}else{
 echo "Username or Email Exists";
 error_log("Failed");
}

//}


// }

?>


<!-- <html>
<head></head>
<body>
<form method="post" action="<?php //echo htmlspecialchars($_SERVER['PHP_SELF']);?>">
	Username: <input type="text" name="username">
	Password: <input type="password" name="password">
	Confirm Password: <input type="password" name="confirmpassword">
	Semester: <input type="text" name="semester">
	Student Id: <input type="text" name="studentId">
	Email: <input type="text" name="email">
	<input type="submit" name="register" value="Register">
</form>
	

</body>
</html> -->