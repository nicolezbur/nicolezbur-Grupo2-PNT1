function registrarCliente() {
    var usuario = document.getElementById("nombre").value;
    var apellido = document.getElementById("apellido").value;
    var correo = document.getElementById("correo").value;
    alert("Se ha registrado crorrectamente a " + usuario + " " + apellido + ", se le enviara un mensaje a su casilla de correo electronico " + correo)
}

function registrarUsuario(){
    
    alert("Se tomó correctamente el registro del usuario " + usuario);
}

function clave(){
    alert(blablabla)
}

function validarClave(){
    let clave1 = document.getElementById("clave1").value;
    let clave2 = document.getElementById("clave2").value;

    if (clave1 == clave2) {
       alert("Ambas contraseñas coinciden");
       return true;
    } else {
       alert("Ambas contraseñas deben coincidir");
       return false;
    }
}

function registrarUsuarios() {
    if (confirm("\u00BFEst\u00E1 seguro de enviar el formulario?")) {

		let resulClave= validarClave(document.getElementById('clave1').value);
        let nombreUsuario = document.getElementById('nombreUsuario').value;

		if (resulClave == true) {
			alert("Se tomó correctamente el registro del usuario " + nombreUsuario);
            return true;    
		}		
	}
	else {
        alert("Las contraseñas no coinciden");
		return false;
	}
}

function registrarVehiculo(){
    let marca = document.getElementById("marca").value;
    let modelo = document.getElementById("modelo").value;
    let patente = document.getElementById("patente").value;

    if (confirm("\u00BFEst\u00E1 seguro de enviar el formulario?")) {
        alert("Se registro correctamente el vehiculo " + marca + " " + modelo + ", patente " + patente);
        return true;
    }
}