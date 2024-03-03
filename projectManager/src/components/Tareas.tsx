import { Card, CardContent, CardHeader } from "@/components/ui/card";

export interface Tareas {
    id: number;
    proyectoId: number;
    detalles: string;
    estado: boolean;
    expireTime: string;
  }
  export interface Props {
    tareas: Tareas[];
    handleClick: (index: number) => void;
  }
  
  export function Tareas({ tareas, handleClick }: Props) {
      return (
        <div className="grid gap-4 grid-cols-3 grid-rows-3 mt-10 mx-auto">
          {tareas?.map((tarea) => (
            <div key={tarea.id} onClick={()=> handleClick(tarea.id)}>
              <Card className="w-[350px] cursor-pointer flex-nowrap">
                <CardHeader></CardHeader>
                <CardContent>
                  <p>{tarea.detalles}</p>
                  <p>{new Date(tarea.expireTime).toLocaleDateString("Es-es")}</p>
                </CardContent>
              </Card>
            </div>
          ))}
        </div>
      );
    }