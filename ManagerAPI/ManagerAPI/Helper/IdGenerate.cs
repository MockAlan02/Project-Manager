using System.Text;

namespace ManagerAPI.Helper
{
    public static class IntIDGenerator
    {
        private static int nextID = 1; // Inicializamos el contador en 1

        public static int GenerateUniqueID()
        {
            // Obtenemos el siguiente ID y luego incrementamos el contador
            int currentID = nextID++;
            return currentID;
        }
    }
}
