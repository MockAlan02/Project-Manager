import { Button } from "@/components/ui/button";

import { useEffect, useState } from "react";
import { useParams } from "react-router";
import CrearTarea from "./Form/CrearTarea";
import { Tareas } from "@/components/Tareas";

// public string? Nombre { get; set; }
// public string? Detalles { get; set; }
// public bool Estado { get; set; }
// public DateTime ExpireTime { get; set; }
export interface DetallesDto {
  Nombre: string;
  Detalles: string;
  Estado: boolean;
  ExpireTime: string;
}
interface Props {
  detalles : DetallesDto;
}
function Detalles ({detalles}: Props){
  return (
    <div className="bg-slate-500 w-full">
      <h1>{detalles.Nombre}</h1>
      <p>{detalles.Detalles}</p>
      <p>{detalles.ExpireTime}</p>
    </div>
  )
}

export default function Tarea() {
  const [open, setOpen] = useState(false);
  const [tareas, setTarea] = useState<Tareas[] | null>(null);

  const { id } = useParams();
  const num = parseInt(id as string);
  const [tareaSeleccionada, setTareaSeleccionada] = useState<number | null>(null);
  const [detalles, setDetalles] = useState<DetallesDto | null>(null);
  const handleClick = (index : number) => {
    if(index == null){
      return;  
    }
    setTareaSeleccionada(index);
  }

  useEffect(() => {
    fetch(`https://localhost:7038/api/Tarea/ProyectoId?id=${id}`)
      .then((response) => response.json())
      .then((data) => {
        if(data== null || data.status == 400){
            return;
        }
        setTarea(data)
      })
      .catch((error) =>
        console.error("Error al obtener los datos de los proyectos:", error)
      );
  }, [id]);
  useEffect(() => {
    if(tareaSeleccionada == null)return;

    fetch(`https://localhost:7038/api/Tarea/Detalles?id=${tareaSeleccionada}`)
    .then(response => response.json())
    .then(data => setDetalles(data))
    .catch(err => console.log(err))
      console.log(detalles)
  }, [tareaSeleccionada]);

  return (
    <main className="w-full h-dvh">
      <div className="relative outline outline-2 outline-offset-2 w-11/12 mx-auto min-h-[80%] p-4 mt-10 overflow rounded-sm">
        <Button className="absolute top-0 right-0 mt-[-1.5rem] mr-[0.9rem] mx-5" onClick={() => setOpen(!open)}>
          Crear Tarea
        </Button>
      

        <div className="flex flex-col">
          <h1 className="text-3xl font-bold">Tarea</h1>
          {tareas && (
             <Tareas tareas={tareas} handleClick={handleClick}/>
            )}
        </div>
        {open && <div className="fixed inset-0 bg-black/90  z-10">  <CrearTarea open={open} onClose={()=> setOpen(!open)} ProyectoId={num}/></div>}
        {detalles && (
          <Detalles detalles={detalles}/>
        )}
      </div>
    </main>
  );
}
