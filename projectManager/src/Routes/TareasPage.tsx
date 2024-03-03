import { Button } from "@/components/ui/button";

import { useEffect, useState } from "react";
import { useParams } from "react-router";
import CrearTarea from "./Form/CrearTarea";
import { Tareas } from "@/components/Tareas";
import { useToast } from "@/components/ui/use-toast"


interface DetallesDto {
  nombre: string;
  detalles: string;
  estado: boolean;
  expireTime: string;
}
interface Props {
  open: boolean;
  onClose: () => void;
  detalles: DetallesDto;
  tareaid: number;
}

export async function deleteItem(itemId :number) {

 
  try {
    const response = await fetch(`https://localhost:7038/api/Facade?id=${itemId}`, {
      method: 'DELETE',
    });

    if (!response.ok) {
      throw new Error('Error al eliminar el item');
    }
   
    return await response.json();
  } catch (error) {
    console.error('Error:', error);
    throw error;
  }
}

function Detalles({ open, onClose, detalles, tareaid }: Props) {
  const { toast } = useToast()
  if (!open) {
    return null;
  }
  return (
    <div className=" w-full h-[80%] flex justify-center items-center flex-col">
      <div className="w-3/12 bg-blue-950 h-auto p-6 rounded-xl">
        <h1 className="text-3xl mb-8 font-bold">Detalles Cliente</h1>
        <p > <span className="font-medium mr-2">Nombre:</span> {detalles.nombre}</p>
        <p > <span className="font-medium mr-2">Detalles:</span> {detalles.detalles}</p>
        <p > <span className="font-medium mr-2">Fecha Vencimiento</span>: {new Date(detalles.expireTime).toLocaleDateString()}</p>
        <p > <span className="font-medium mr-2">Estado:</span> {detalles.estado ? "Activo" : "Inactivo"}</p>
        <div className="w-full flex justify-end  gap-x-3 mt-4">
        <Button type="button" className="w-[120px] " onClick={onClose}> Cerrar
        </Button >
        <Button variant="destructive" className="w-[120px]" onClick={() => {deleteItem(tareaid)
         toast({
          title: "Borrado Exitoso.",
          description: "La tarea del cliente ha sido Eliminado con exito",
        })}}>
          Borrar
        </Button>
        </div>
         
      </div>
    </div>
  );
}

export default function Tarea() {
  const [open, setOpen] = useState(false);
  const [open2, setOpen2] = useState(false);
  const [tareas, setTarea] = useState<Tareas[] | null>(null);

  const { id } = useParams();
  const num = parseInt(id as string);
  const [tareaSeleccionada, setTareaSeleccionada] = useState<number | null>(
    null
  );
  const [detalles2, setDetalles] = useState<DetallesDto | null>(null);
  const handleClick = (index: number) => {
    if (index == null) {
      return;
    }
    setTareaSeleccionada(index);
  };

  useEffect(() => {
    fetch(`https://localhost:7038/api/Facade/ProyectoId?id=${id}`)
      .then((response) => response.json())
      .then((data) => {
        if (data == null || data.status == 400) {
          return;
        }
        setTarea(data);
      })
      .catch((error) =>
        console.error("Error al obtener los datos de los proyectos:", error)
      );
  }, [id]);

  useEffect(() => {
    if (tareaSeleccionada == null) return;

    fetch(`https://localhost:7038/api/Facade/Detalles?id=${tareaSeleccionada}`)
      .then((response) => response.json())
      .then((data) => setDetalles(data))
      .catch((err) => console.log(err));
      console.log(detalles2)

    if (detalles2 != null) setOpen2(true);
  }, [tareaSeleccionada]);

  return (
    <main className="w-full max-h-[100%]">
      <div className="relative outline outline-2 outline-offset-2 w-11/12 mx-auto min-h-[90%] p-4 mt-10 overflow rounded-sm">
        <Button
          className="absolute top-0 right-0 mt-[-1.5rem] mr-[0.9rem] mx-5"
          onClick={() => setOpen(!open)}
        >
          Crear Tarea
        </Button>

        <div className="flex flex-col">
          <h1 className="text-3xl font-bold">Tarea</h1>
          {tareas && <Tareas tareas={tareas} handleClick={handleClick} />}

          {open2 && detalles2 && (
            <div className="fixed inset-0 bg-black/90  z-10">
              <Detalles
                detalles={detalles2}
                open={open2}
                onClose={() => setOpen2(!open2)}
                tareaid={tareaSeleccionada as number}
              />
            </div>
          )}
        </div>
        {open && (
          <div className="fixed inset-0 bg-black/90  z-10">
            {" "}
            <CrearTarea
              open={open}
              onClose={() => setOpen(!open)}
              ProyectoId={num}
            />
          </div>
        )}
      </div>
    </main>
  );
}
