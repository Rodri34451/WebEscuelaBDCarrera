const $$Nav=function(){

    this.init = () => {
        $ds.nav("body");
        $dn.makeButton("Inicio",$ds.home);
        $dn.makeButton("Carrera",$f.addUser);
        $dn.makeButtonLogin("Ingresar")
        $dn.makeDropDown("Funciones",["abm usuario","Buscar Usuario","abm carrera","Buscar Carrera"],[$f.addUser,$f.findUser,$f.addCarrera,$f.findCarrera]);

    }

}

const $nav=new $$Nav