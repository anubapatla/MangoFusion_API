import Headers from './components/layout/Header'
import './App.css'
import Approutes from './routes/AppRouter'
import Footer from './components/layout/Footer'

function App() {
  return (
    <div className="d-flex flex-column min-vh-100 bg-body">
      <Headers/>
      <main className="flex-grow-1">
      <Approutes/>
      </main>
      <Footer/>              
      
    </div>
  );
}

export default App
