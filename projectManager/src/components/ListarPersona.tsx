
  export interface Personas {
    id: number;
    correo: string;
    contrasena: string;
    userDetail: PersonaDetail;
    rol: string;
  }
  interface PersonaDetail {
    id: number;
    nombre: string;
    edad: number;
    fechaNacimiento: string;
    direccion: string;
  }
  interface Props {
    personas: Personas[];
  }
  
  
  export function ListarPersona({ personas }: Props) {
    return (
      <>
        {personas.map((persona) => (
          <option key={persona.id} value={persona.id} className="bg-dark-color">
            {persona.userDetail.nombre}
          </option>
        ))}
      </>
    );
  }