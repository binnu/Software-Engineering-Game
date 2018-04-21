<?php
session_start();

require_once("UserController.php");
$uc = new UserController();
// if (isset($_POST['login']) && !empty($_POST['username']) && !empty($_POST['password'])){
$username = $_POST['username'];
	$password = $_POST['password'];

	$result = $uc->validateLogin($username , $password);
	if($result){
 	echo "logged in";

 	if (isset($_SESSION['username'])) {
$username_session = $_SESSION['username'];
 	}
 } else{
 	echo "invalid credentials";
 }
//}
?>


<!-- <html>
<head></head>
<body>
<form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']);?>">
	Username: <input type="text" name="username">
	Password: <input type="password" name="password">
	<input type="submit" name="login" value="Login">
</form>
	

</body>
</html> -->