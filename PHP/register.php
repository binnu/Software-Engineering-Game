<?php
session_start();

require_once("UserController.php");
$uc = new UserController();


	$username = $_POST['username'];
	$password = $_POST['password'];
	$confPassword = $_POST['confPassword'];
	$semester = $_POST['semester'];
	$studentId = $_POST['studentId'];
	$email = $_POST['email'];


if(!(strlen($username)>15)) {
	
	if(!(strlen($email)>15) && filter_var($email, FILTER_VALIDATE_EMAIL)){
    if(($password == $confPassword)){
	if( !(strlen($password) < 6 ) && (preg_match("#[0-9]+#", $password))&& (preg_match("#[a-z]+#", $password)) && (preg_match("#[A-Z]+#", $password)) && (preg_match("/[\'^£$%&*()}{@#~?><>,|=_+!-]/", $password))) {
        
		if(is_numeric($studentId)){

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
		}
	
	else{
			echo "Student Id should be numeric";
		}
	}else{
		echo "password format is not correct";
	}
	}else{
		echo "Password's don't match";
	}
	}else{
		echo "Invalid Email";
	}
	}else{
		echo "username should be less than 15 characters";
	}



?>
