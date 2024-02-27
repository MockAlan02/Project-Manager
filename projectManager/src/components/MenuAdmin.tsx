
import { Navbar } from 'flowbite-react';

export default function MenuAdmin() {
  return (
    <Navbar fluid rounded className='fixed w-full'>
      <Navbar.Brand  href="/">
        
        <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">Flowbite React</span>
      </Navbar.Brand>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Navbar.Link href="/">Logout</Navbar.Link>
      </Navbar.Collapse>
    </Navbar>
  );
}