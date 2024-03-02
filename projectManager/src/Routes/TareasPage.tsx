import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader } from "@/components/ui/card";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import CrearTarea from "./Form/CrearTarea";

interface Tareas {
  id: number;
  proyectoId: number;
  detalles: string;
  estado: boolean;
  expireTime: string;
}
interface Props {
  tareas: Tareas[];
}

function Tareas({ tareas }: Props) {
    return (
      <div className="grid gap-4 grid-cols-3 grid-rows-3 mt-10 mx-auto">
        {tareas?.map((tarea, index) => (
          <div key={index}>
            <Card className="w-[350px] cursor-pointer flex-nowrap">
              <CardHeader></CardHeader>
              <CardContent>
                <p>{tarea.detalles}</p>
                <p>{tarea.expireTime}</p>
              </CardContent>
            </Card>
          </div>
        ))}
      </div>
    );
  }


export default function Tarea() {
  const [open, setOpen] = useState(false);
  const [tareas, setTarea] = useState<Tareas[] | null>(null);
  const { id } = useParams();
  const num = parseInt(id as string);
  useEffect(() => {
    fetch(`https://localhost:7038/api/Tarea/id?id=${id}`)
      .then((response) => response.json())
      .then((data) => {
        if(data== null || data.status == 400){
            return;
        }
        setTarea([data])
      })
      .catch((error) =>
        console.error("Error al obtener los datos de los proyectos:", error)
      );
  }, [id]);
  return (
    <main className="w-full h-dvh">
      <div className="relative outline outline-2 outline-offset-2 w-11/12 mx-auto min-h-[80%] p-4 mt-10 overflow rounded-sm">
        <Button className="absolute top-0 right-0 mt-[-1.5rem] mr-[0.9rem] mx-5" onClick={() => setOpen(!open)}>
          Crear Tarea
        </Button>
      

        <div className="flex flex-col">
          <h1 className="text-3xl font-bold">Tarea</h1>
          {tareas && (
             <Tareas tareas={tareas} />
            )}
        </div>
        {open && <div className="fixed inset-0 bg-black/90  z-10">  <CrearTarea open={open} onClose={()=> setOpen(!open)} ProyectoId={num}/></div>}
       
      </div>
    </main>
  );
}
