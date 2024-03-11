export async function getProyecto(){
    const response = await fetch("https://localhost:7038/api/Facade/Proyectos")
    .then((response) => response.json())
    .catch((error) =>
      console.error("Error al obtener los datos de los proyectos:", error)
    );
    return response;
} 