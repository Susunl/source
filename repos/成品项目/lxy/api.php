<?php
//
register_shutdown_function('shutdown');
//


if ( empty( $_GET ) || ( $_GET['action'] != 'get' && $_GET['action'] != 'update' ) ){
	$output = [
		'msg'=>'No action do?',
		'TryAgain' =>1
	];
	echo json_encode( $output );
	die();
}

//setcookie( 'info', '534e3601662eced686a0fab2fd886170' );
session_name('info' );
session_start();

//set session
//echo "session: ";
if ( !empty( $_GET['debug'] ) ){
	var_dump( $_SESSION['data']);
}
//var_dump($_SESSION['data']['data']);
//echo "<br>";
/**
 * 获取数据
 */
if ( $_GET['action'] == 'get' ){
	if ( array_key_exists( 'data', $_SESSION ) && !empty( $_SESSION['data'] ) ){
		//var_dump( $_SESSION['data']['data'] );
		if ( empty( $_GET['debug'] ) ){
			header( 'Content-type: application/json' );
		}

		$d = $_SESSION['data'];
		echo output( $d );
	}else{
		//默认数据
		$data = ['msg'=>'no data'];
		echo output( $data );
	}
	die();
}


/**
 * 更新数据
 */
if ( $_GET['action'] == 'update' && !empty( $_POST ) && !empty( $_POST['data'] ) ){
	shift();
	$data = formatData( $_POST['data'] );
	if ( !array_key_exists( 'data', $_SESSION ) ){
		$s = ['status'=>1,'data'=>[]];
	}else{
		 $s = $_SESSION['data'];
	}

	$s['data'][]=$data;
	$_SESSION['data'] = $s;
	die();
}


//没有执行任何行为
$msg = ['msg'=>'No action do!'];
echo output( $msg );


/**
 * 输出编码
 * @param array $data
 *
 * @return string
 */
function output( $data = [] ){

	if ( empty( $data ) || !is_array( $data  ) ){
		die();
	}

	$result = json_encode( $data, JSON_HEX_TAG | JSON_HEX_APOS | JSON_HEX_QUOT | JSON_HEX_AMP | JSON_UNESCAPED_UNICODE );
	if ( json_last_error() == 0 ){
		return $result;
	}else{
		$result = json_encode( ['msg'=>'Encode Error'], JSON_HEX_TAG | JSON_HEX_APOS | JSON_HEX_QUOT | JSON_HEX_AMP | JSON_UNESCAPED_UNICODE );
		return $result;
	}
}

/**
 * 格式化输入
 * @param string $data
 *
 * @return array
 */
function formatData( $data = '' ){
	if ( !empty( $data ) && is_string( $data ) ){
		$a_ = json_decode( $data, true );
		$time = (string)time();
		$a_['time']=$time;
		$a = $a_;
	}else{
		$a = '';
	}
	return $a;
}


function shutdown() {
	$e = error_get_last();
	//var_dump( $e );
	die();
}

function shift(){
	if ( isset( $_SESSION ) && !empty( $_SESSION ) && !empty( $_SESSION['data'] ) && !empty( $_SESSION['data']['data'] ) ){
		$count = count( $_SESSION['data']['data'] );
		if ( $count >= 20 ) array_shift( $_SESSION['data']['data'] );
	}
}

