# 变量
# 类变量：  class varible     @@color   作用域：多个实例共享
# 实例变量：instance varible  @color    作用域：仅在instance内
# 普通变量：local varible     age       作用域：在方法内
# 全部变量：global varible    $name     作用域：在全局

class Apple

    @@from="china"

    #setter
    def color= color
        #instance variable ,不需要声明
        @color=color
    end

    #getter
    def color
        return @color
    end 

    def get_from
        @@from
    end

    def set_from from
        @@from=from
    end
end

red_apple=Apple.new
red_apple.color="red"
puts red_apple.color

red_apple.set_from("Japan")
puts red_apple.get_from

green_apple=Apple.new
green_apple.color="green"
puts green_apple.color

puts green_apple.get_from()