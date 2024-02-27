import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

export default function LoginPage(){
    return (
        <main className="w-full h-screen flex justify-center items-center bg-custom-blue">
        <div className="w-2/6 bg-custom-blue-2 p-4 gap-8 rounded-3xl">
            <form className="gap-4 p-10 flex flex-col">
                 <h1 className="text-white  text-center text-3xl mb-6">Iniciar Sesion</h1>
                 <p>Iniciar sesion para administrar tu cuenta</p>
          <Input type="email" placeholder="Email"/>
          <Input type="password" placeholder="Password" />
          <Button className="w-full p-6">Iniciar Sesion</Button>
            </form>
            <p>No tienes cuenta? <span>Registrate</span></p>
            <p>Olvidaste la Contraseña</p>
        </div>
      </main>
      
    );
}