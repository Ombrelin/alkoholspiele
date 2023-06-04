package arsenelapostolet.fr.alkoholspiele
import io.ktor.server.application.*
import arsenelapostolet.fr.alkoholspiele.plugins.*


fun main(args: Array<String>): Unit =
    io.ktor.server.netty.EngineMain.main(args)

@Suppress("unused") // application.conf references the main function. This annotation prevents the IDE from marking it as unused.
fun Application.module() {
    configureSerialization()
    configureRouting()
}
