import { ListarPersona, Personas } from "@/components/ListarPersona";
import {Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { Input } from "@/components/ui/input";
import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover";
import { cn } from "@/lib/utils";

import { format } from "date-fns";
import { CalendarIcon } from "lucide-react";
import React, { useEffect, useState  } from "react";
import { useForm, SubmitHandler } from "react-hook-form";
type CrearTareaProps = {
    open: boolean;
    onClose: () => void;
    ProyectoId: number;
    };
export default function CrearTarea({open , onClose, ProyectoId}: CrearTareaProps) {

type Inputs = {
    ProyectoId: number;
    Detalles: string;
    Estado: boolean;
    ExpireTime: Date;
    PersonaId: number;
  };
  
  const [date, setDate] = React.useState<Date>()
  const [persona, SetPersona] = useState<Personas[] | null>(null);

  useEffect(() => {
    fetch("https://localhost:7038/api/Usuario/All")
      .then((response) => response.json())
      .then((data) => {
        SetPersona(data);
      })
      .catch((error) =>
        console.error("Error al obtener los datos de los proyectos:", error)
      );
  }, []);


  const {
    register,
    formState: { errors },
    handleSubmit 
  } = useForm<Inputs>();

  const onSubmit: SubmitHandler<Inputs> = (data, e) => {
    e?.preventDefault();
    console.log(ProyectoId)
    data = {...data, ExpireTime: new Date(date?.toISOString() as string) , "ProyectoId": ProyectoId}
    data.Estado = true
    console.log(data)
    fetch("https://localhost:7038/api/Tarea/Crear", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log("Success:", data);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }
 
  if(!open) {return null}
  return (
    <div className="w-full h-dvh">
      <form
       onSubmit={handleSubmit(onSubmit)}
        className="w-5/12 mx-auto mt-40 flex flex-col gap-8"
      >
       
        <div>
          <label>Detalles</label>
          <Input
            className="mt-2"
            type="text"
            {...register("Detalles", { required: true })}
          />
          {errors.Detalles && <span>This field is required</span>}
        </div>

        <div className="flex flex-col w-full" >
         <label htmlFor="no" className="mb-4" >Escoge un estado:</label>
          <select id="no" className="bg-transparent rounded-xl border-blue-900"   {...register("Estado", { required: true })}>
            <option value="" className="bg-dark-color">Selecciona Estado</option>
           <option value="true" className="bg-dark-color">Activo</option>
              <option value="false" className="bg-dark-color">Inactivo</option>
          </select>
         </div>

        <div className="flex flex-col w-full">
        <label>Tiempo de expiracion</label>
        <Popover>
      <PopoverTrigger asChild>
        <Button
          variant={"outline"}
          className={cn(
            "w-full justify-start text-left font-normal mt-4",
            !date && "text-muted-foreground"
          )}
        >
          <CalendarIcon className="mr-2 h-4 w-4" />
          {date ? format(date, "PPP") : <span>Pick a date</span>}
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-auto p-0">
        <Calendar
          mode="single"
          selected={date}
          onSelect={(newDate) => {   
            setDate(newDate)
          }}
          initialFocus
        />
      </PopoverContent>
    </Popover>
        </div>

        <div>
         <div className="flex flex-col w-full" >
         <label htmlFor="Persona" className="mb-4" >Selecciona una persona:</label>
          <select id="cars" className="bg-transparent rounded-xl border-blue-900"   {...register("PersonaId", { required: true })}>
            <option value="" className="bg-dark-color">Selecciona la persona</option>
            {persona && <ListarPersona personas={persona} />}
          </select>
         </div>
       
        </div>
        <div className="flex w-full justify-end gap-x-6">
          <Button type="button" className="w-[120px]" onClick={onClose}>Cerrar</Button>
        <Button type="submit" className="w-[120px]">Submit</Button>
        </div>
      </form>
    </div>
  );
}
