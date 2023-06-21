import scala.collection.mutable.ListBuffer

//Global Variables
var lives = 5
var coins = 0
var map = new ListBuffer[String]

//Methods
def UpdateMap(x: Int, y: Int, size: Int): Unit = {
  for (i <- 0 until size) {
    for (j <- 0 until size) {
      map.append(s"($x+$i,$y+$j)")
    }
  }
}

def Move(x: Int, y: Int): Unit = {
  if (lives > 0) {
    var nextX = x + 1
    var nextY = y + 1
    UpdateMap(nextX, nextY, 3)
    println(s"Moved to position ($nextX,$nextY)")
  } else {
    println("You do not have enough lives to move.")
  }
}

def CollectCoins(): Unit = {
  if (map.contains((x+1,y+1))) {
    coins += 1
    println("You have collected "+coins+" coins.")
  }
}

def Fight(): Unit = {
  if (map.contains((x+1,y+1))) {
    lives -= 1
    println("You have "+lives+" left.")
  }
}

def PrintMap(): Unit = {
  println("The map is now:")
  for (i <- 0 until map.length) {
    print(map(i)+"  ")
  }
  println()
}

//Main
println("Welcome to Planet Quest!")
while (lives > 0) {
  println("The current position is (x,y):")
  val x = scala.io.StdIn.readInt()
  val y = scala.io.StdIn.readInt()
  UpdateMap(x, y, 3)
  println("What would you like to do?")
  println(" 1. Move\n 2. Collect Coins\n 3. Fight\n 4. Print Map")
  val choice = scala.io.StdIn.readInt()
  choice match {
    case 1 => Move(x, y)
    case 2 => CollectCoins()
    case 3 => Fight()
    case 4 => PrintMap()
  }
}

println("You have run out of lives. Game Over!")