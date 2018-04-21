<?php
session_start();

require_once("UserController.php");
$uc = new UserController();

    $username = $_POST['username'];
	$score = $_POST['score'];
	
 $result = $uc->insertScore($username,$score);
 
echo "inserted succesfully";

?>