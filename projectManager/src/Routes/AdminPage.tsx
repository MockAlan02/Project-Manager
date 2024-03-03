import { Button } from "@/components/ui/button";
import { Card, CardTitle, CardHeader, CardContent } from "@/components/ui/card";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
interface Proyecto {
  id: number;
  nombre: string;
  descripcion: string;
  startTime: string;
  endTime: string;
}

interface Props {
  proyectos: Proyecto[];
}

function Proyectos({ proyectos }: Props) {
  return (
    <div className="grid gap-4 grid-cols-3 grid-rows-3 mt-10 mx-auto">
      {proyectos.map((proyecto) => (
        <Link to={`${proyecto.id}`} key={proyecto.id}>
          <Card className="w-[350px] cursor-pointer flex-nowrap">
            <CardHeader>
              <CardTitle>{proyecto.nombre}</CardTitle>
            </CardHeader>
            <CardContent>
              <p>{proyecto.descripcion}</p>
              <p>{proyecto.startTime}</p>
            </CardContent>
          </Card>
        </Link>
      ))}
    </div>
  );
}

export default function AdminPage() {
  // const { id } = useParams();
  const [datosProyecto, setDatosProyecto] = useState<Proyecto[] | null>(null);

  useEffect(() => {
    // Llamar a la API para obtener los datos de los proyectos
    fetch("https://localhost:7038/api/Facade/Proyectos")
      .then((response) => response.json())
      .then((data) => setDatosProyecto(data))
      .catch((error) =>
        console.error("Error al obtener los datos de los proyectos:", error)
      );
  }, []);

  return (
    <main className="w-full h-dvh">
      <div className="relative outline outline-2 outline-offset-2 w-11/12 mx-auto min-h-[80%] p-4 mt-10 overflow rounded-sm">
        <Button className="absolute top-0 right-0 mt-[-1.5rem] mr-[0.9rem] mx-5">
          Crear Proyecto
        </Button>
        <div className="flex flex-col">
          <h1 className="text-3xl font-bold">Proyectos</h1>
          {datosProyecto && <Proyectos proyectos={datosProyecto} />}
        </div>
      </div>
    </main>
  );
}
