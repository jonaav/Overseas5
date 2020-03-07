/*
* PINTAR BOTONES DE LOS TIPOS DE CURSOS
*/

function ActivarColorBoton(boton){
    $('#btn'+boton).removeClass('btn-outline-info');
    $('#btn'+boton).addClass('btn-info');                        
}


function DesactivarColorBoton(boton){
    $('#btn'+boton).removeClass('btn-info');
    $('#btn'+boton).addClass('btn-outline-info');
    
}

function ActivarColorBotonEstado(boton, color){
    $('#btn'+boton).removeClass('btn btn-outline-'+ color);
    $('#btn'+boton).addClass('btn btn-'+ color);  
}

function DesactivarColorBotonEstado(boton, color){
    $('#btn'+boton).removeClass('btn btn-'+ color);
    $('#btn'+boton).addClass('btn btn-outline-' + color);
}


function PintarBotonTipoCurso(nombreCurso){
    let tipoCursos = ['InglesGeneral', 'InglesNiños', 'ExamInter', 'OtrosIdiomas', 'Domicilio', 'Corporativo'];    
    ActivarColorBoton(nombreCurso);
    for(let i=0; i<tipoCursos.length; i++){        
        if(nombreCurso != tipoCursos[i])                    
            DesactivarColorBoton(tipoCursos[i]);                
    }
}
