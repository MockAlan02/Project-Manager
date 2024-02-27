import {Button } from "@/components/ui/button";
export default function AdminPage(){
    return (
        <div className="w-full h-dvh mt-3">
        <div className="w-full bg-blue-700">
          <h1>Admin Page</h1>
          <Button>Asignar Tarea</Button>
          <p>Datos de los Usuarios</p>
          <h1>Tabla</h1>
        </div>
        <div className="fixed bottom-0 left-0 w-full bg-blue-700">
        </div>
        
      </div>
    );
}